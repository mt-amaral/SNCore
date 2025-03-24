using System.ComponentModel.DataAnnotations;

namespace Admin.Shared.Request.Connection;

public class TestSnmpRequest
{
    [Required]
    public int HostId { get; set; }
    [Required]
    public string Oid { get; set; } = string.Empty;
    public bool Descovery { get; set; } = false;
}