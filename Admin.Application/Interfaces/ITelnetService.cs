﻿using Admin.Share.Response;
using Admin.Share.Request;


namespace Admin.Application.Interfaces;

public interface ITelnetService
{
    Task<TelnetResponse> SelectByPk(int id);
    Task<IEnumerable<TelnetResponse>> SelectAll();
    Task Create(TelnetRequest telnetRequest);
    Task Edit(TelnetRequest telnetRequest);
    Task Delete(int snmpId);
}
