﻿using Admin.Application.DTOs;
using Admin.Domain.Entities;
using System.Threading.Tasks;


namespace Admin.Application.Interfaces;

public interface IHardwareService
{
    Task<HardwareDTO> SelectByPk(int id);
    Task<IEnumerable<HardwareDTO>> SelectAll();
    Task Edit(HardwareDTO hardwareDTO);
    Task Delete(HardwareDTO hardwareDTO);
}
