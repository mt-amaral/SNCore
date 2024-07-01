

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Admin.Share.Response;

public class TelnetResponse
{
    public int Id { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public int Port { get; set; }
    public int HardwareId { get; set; }
}