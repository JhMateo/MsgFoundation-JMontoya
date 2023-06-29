using Camunda.Api.Client;
using MsgFoundation.Data;
using MsgFoundation.Models;
using Camunda.Api.Client.ExternalTask;
using Camunda.Api.Client.ProcessInstance;

namespace MsgFoundation.Functions
{
    public class MotociclistaFunctions
    {
        // Función para ver si el motociclista existe en la DB
        public static async Task ExistMotociclista(ExternalTaskInfo task, MsgFoundationContext dbcontext, CamundaClient camunda)
        {

            Dictionary<string, VariableValue> variables = await camunda.Executions[task.ExecutionId].LocalVariables.GetAll();
            string cedula = variables["cedula"].GetValue<string>();

            Motociclista registered = dbcontext.Motociclistas.Where(u => u.Cedula == cedula).FirstOrDefault();

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

            VariableResource vars = camunda.ProcessInstances[task.ProcessInstanceId].Variables;
            await vars.SetBinary("Docvar", new BinaryDataContent(File.OpenRead("document2.doc")), BinaryVariableType.Bytes);



            if (registered != null)
            {
                request.Variables.Add("registered", VariableValue.FromObject(true));
                await camunda.ExternalTasks[task.Id].Complete(request);
            }
            else
            {
                request.Variables.Add("registered", VariableValue.FromObject(false));
                await camunda.ExternalTasks[task.Id].Complete(request);

            }


        }

        // Función para crear al motociclista
        public static async Task CreateMotociclista(ExternalTaskInfo task, MsgFoundationContext dbcontext, CamundaClient camunda)
        {

            Dictionary<string, VariableValue> variables = await camunda.Executions[task.ExecutionId].LocalVariables.GetAll();
            string cedula = variables["cedula"].GetValue<string>();
            string fullName = variables["fullname"].GetValue<string>();
            string placaMoto = variables["placamoto"].GetValue<string>();
            string marcaMoto = variables["marcamoto"].GetValue<string>();
            string modeloMoto = variables["modelomoto"].GetValue<string>();
            string email = variables["email"].GetValue<string>();


            Motociclista motociclista = new Motociclista
            {
                Cedula = cedula.ToString(),
                FullName = fullName.ToString(),
                Email = email.ToString(),
                PlacaMoto = placaMoto.ToString(),
                MarcaMoto = marcaMoto.ToString(),
                ModeloMoto = modeloMoto.ToString()
            };

            dbcontext.Motociclistas.Add(motociclista);
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

            await camunda.ExternalTasks[task.Id].Complete(request);


        }

        public static async Task ValidateMotociclista(ExternalTaskInfo task, MsgFoundationContext dbcontext, CamundaClient camunda)
        {

            Dictionary<string, VariableValue> variables = await camunda.Executions[task.ExecutionId].LocalVariables.GetAll();
            string cedula = variables["cedula"].GetValue<string>();

            Motociclista login = dbcontext.Motociclistas.Where(u => u.Cedula == cedula).FirstOrDefault();

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

            VariableResource vars = camunda.ProcessInstances[task.ProcessInstanceId].Variables;
            await vars.SetBinary("Docvar", new BinaryDataContent(File.OpenRead("document3.doc")), BinaryVariableType.Bytes);

            if (login != null)
            {
                request.Variables.Add("cedula", VariableValue.FromObject(login.Cedula));
                request.Variables.Add("placamoto", VariableValue.FromObject(login.PlacaMoto));
                request.Variables.Add("login", VariableValue.FromObject(true));
                await camunda.ExternalTasks[task.Id].Complete(request);
            }
            else
            {
                request.Variables.Add("login", VariableValue.FromObject(false));
                await camunda.ExternalTasks[task.Id].Complete(request);

            }



        }


        
    }
}

