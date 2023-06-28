using System.ComponentModel.DataAnnotations;

namespace MsgFoundation.Models
{
    public class Motociclista
    {
        [Key]
        public string Cedula { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PlacaMoto { get; set; }
        public string MarcaMoto { get; set; }
        public string ModeloMoto { get; set; }

    }
}
