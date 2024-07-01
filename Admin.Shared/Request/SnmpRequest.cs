

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Admin.Share.Response;

public class SnmpRequest
{
    [IgnoreDataMember]
    public int Id { get; set; }
    [Required]
    public string Version { get; set; }
    [Required]
    public string Community { get; set; }
    [Required]
    public int Port { get; set; }
    [Required]
    public int HardwareId { get; set; }
}