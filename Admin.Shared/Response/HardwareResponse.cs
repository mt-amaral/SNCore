
using Admin.Shared.Base;
namespace Admin.Shared.Response;

public class HardwareResponse : HardwareBase
{
    public int Id { get; set; }
    public bool IsOnline { get; set; }

}