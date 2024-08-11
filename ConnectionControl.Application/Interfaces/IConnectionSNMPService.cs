using ConnectionControl.Application.Dtos.Request;


namespace ConnectionControl.Application.Interfaces;

public interface IConnectionSNMPService
{
    Task SimpleSNPM(ConnectionSNMPDto connectionSNMPD);
}
