using System.ComponentModel.DataAnnotations;

namespace MsgFoundation.Models
{
    public class Tecnomecanica
    {
        [Key]
        public Guid Id { get; set; }
        public string Cedula { get; set; }
        public string PlacaMoto { get; set; }
        public DateTime FechaExp { get; set; }
        public DateTime FechaVen { get; set; }
    }
}
