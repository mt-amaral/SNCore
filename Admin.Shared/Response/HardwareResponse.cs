
using Admin.Share.Enums;
namespace Admin.Share.Response;

public class HardwareResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsOnline  {  get; set; }
    public string Description { get; set; }
    public  Model HardwareModel  { get; set; }
    public string Ipv4 { get; set; }
}