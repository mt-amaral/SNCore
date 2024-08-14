﻿using Admin.Shared.Response;
using Admin.Shared.Request;


namespace Admin.Application.Interfaces;

public interface IHardwareService
{
    Task<HardwareResponse> SelectByPk(int id);
    Task<IEnumerable<HardwareResponse>> SelectAll();
    Task Create(HardwareRequest hardwareRequest);
    Task Edit(HardwareRequest hardwareRequest);
    Task Delete(int hardwareId);
}
