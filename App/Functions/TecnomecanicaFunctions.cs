using Camunda.Api.Client.ExternalTask;
using Camunda.Api.Client;
using MsgFoundation.Data;
using MsgFoundation.Models;

namespace MsgFoundation.Functions
{
    public class TecnomecanicaFunctions
    {
        public static async Task CreateTecnomecanica(ExternalTaskInfo task, MsgFoundationContext dbcontext, CamundaClient camunda)
        {
            Dictionary<string, VariableValue> variables = await camunda.Executions[task.ExecutionId].LocalVariables.GetAll();
            string cedula = variables["cedula"].GetValue<string>();
            string placaMoto = variables["placamoto"].GetValue<string>();

            Tecnomecanica tecnomecanica = new Tecnomecanica
            {
                Id = Guid.NewGuid(),
                Cedula = cedula,
                PlacaMoto = placaMoto,
                FechaExp = DateTime.UtcNow,
                FechaVen = DateTime.UtcNow.AddYears(1)
            };

            dbcontext.Tecnomecanicas.Add(tecnomecanica);
            dbcontext.SaveChanges();

            FetchExternalTasks fetch = new FetchExternalTasks();
            fetch.WorkerId = "worker";
            fetch.MaxTasks = 1;
            fetch.UsePriority = true;
            fetch.Topics = new List<FetchExternalTaskTopic>();
            fetch.Topics.Add(new FetchExternalTaskTopic(task.TopicName, 1));

            List<LockedExternalTask> lockedTasks = await camunda.ExternalTasks.FetchAndLock(fetch);

            CompleteExternalTask request = new CompleteExternalTask();
            request.WorkerId = "worker";
            request.Variables = new Dictionary<string, VariableValue>();
            request.Variables.Add("idTecnomecanica", VariableValue.FromObject(tecnomecanica.Id));

            await camunda.ExternalTasks[task.Id].Complete(request);
        }

    }
}
