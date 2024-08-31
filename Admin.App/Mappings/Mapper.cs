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
            Model = hardwareEdit.Model,
            Ipv4 = hardwareEdit.Ipv4
        };
    }
    public static HardwareBase MapperToJson(HardwareBase hardwareEdit, SnmpBase snmpEdit)
    {
        return new HardwareBase()
        {
            Name = hardwareEdit.Name,
            Description = hardwareEdit.Description,
            Model = hardwareEdit.Model,
            Ipv4 = hardwareEdit.Ipv4,
            Snmp = new SnmpBase()
            {
                SnmpVersion = snmpEdit.SnmpVersion,
                Community = snmpEdit.Community,
                Port = snmpEdit.Port,
            }
        };
    }
}

