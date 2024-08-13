namespace ConnectionControl.Application.Dtos.Request;

public class ConnectionSNMPDto
{
    public string Ipv4 { get; set; }
    public int Port { get; set; }
    public string Community { get; set; }
    public string Oid { get; set; }
    public bool Writing { get; set; }
    public bool Reading { get; set; }
}
