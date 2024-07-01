

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Admin.Share.Request;

public class TelnetRequest
{
    [IgnoreDataMember]
    public int Id { get; set; }
    [Required]
    public string User { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public int Port { get;  set; }
    [Required]
    public int HardwareId { get; set; }
}