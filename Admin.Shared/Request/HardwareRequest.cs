using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Admin.Share.Request;

public class HardwareRequest
{
    [IgnoreDataMember]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Description { get; set; }
    [Required]
    [StringLength(50)]
    public string Model { get; set; }
    [Required]
    [StringLength(15)]
    public string Ipv4 { get; set; }
}