using Admin.Shared.Request;
using Admin.Shared.Response;

namespace Admin.App.Mappers;

public class Mapper
{
    public static HardwareRequest MapperToJson(HardwareResponse hardwareEdit)
    {

        return new HardwareRequest()
        {
            Id = hardwareEdit.Id,
            Name = hardwareEdit.Name,
            Description = hardwareEdit.Description,
            HardwareModel = hardwareEdit.HardwareModel,
            Ipv4 = hardwareEdit.Ipv4
        };


    }

}

