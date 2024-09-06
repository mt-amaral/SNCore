namespace Admin.Shared.Payload;

public enum SNMPVersion : short
{
    v1 = 0,
    v2 = 1,
    v3 = 2
}
public class SnmpPayload
{
    public SNMPVersion SnmpVersion { get; set; }
    public string Community { get; set; }
    public int Port { get; set; }
}
