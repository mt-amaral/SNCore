using Admin.Share.Request;
using Admin.Share.Response;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Admin.App.Mappers;

public class Mapper
{
    public static HardwareRequest MapperToJson(HardwareResponse hardwareEdit) 
    {

            return new HardwareRequest()
            {
                Id = hardwareEdit.Id,
                Description = hardwareEdit.Description,
                Model = hardwareEdit.Model,
                Ipv4 = hardwareEdit.Ipv4
            };

        
    }

}

