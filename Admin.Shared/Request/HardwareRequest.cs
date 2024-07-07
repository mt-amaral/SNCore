using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Admin.Share.Request
{
    public class HardwareRequest
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descricao é obrigatória")]
        [StringLength(50, ErrorMessage = "Descrição muito longa")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Model é obrigatória")]
        [StringLength(50, ErrorMessage = "Modelo muito longo")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Ipv4 é obrigatória")]
        [StringLength(15, ErrorMessage = "IPv4 inválido")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Formato de IPv4 inválido")]
        public string Ipv4 { get; set; }
    }
}
