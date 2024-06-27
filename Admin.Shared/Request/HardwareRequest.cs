using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Admin.Share.Request;

public class HardwareRequest
{
    [IgnoreDataMember]
    public int Id { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
    [StringLength(300)]
    public string Model { get; set; }
    [Required]
    [StringLength(15)]
    public string Ipv4 { get; set; }
}