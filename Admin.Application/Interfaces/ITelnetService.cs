﻿
using Admin.Shared.Payload;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface ITelnetService
{
    Task<TelnetResponse> SelectByPk(int id);
    Task<IEnumerable<TelnetResponse>> SelectAll();
    Task Create(int hardwareId, TelnetPayload telnetRequest);
    Task Edit(int Id, TelnetPayload telnetRequest);
    Task Delete(int snmpId);
    Task<TelnetResponse> SelectByHardwareId(int id);
}
