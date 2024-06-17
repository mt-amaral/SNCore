using Admin.Application.DTOs;
using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HardwareController : Controller
{
    private readonly IHardwareService _hardwareService;
    private readonly IMapper _mapper;

    public HardwareController(IHardwareService hardwareService, IMapper mapper)
    {
        _mapper = mapper;
        _hardwareService = hardwareService;
    }

    [HttpGet]
    [Route("ExibirTodos")]
    public async Task<ActionResult<IEnumerable<Hardware>>> GetHardware()
    {
        try
        {
            var hardwareList = await _hardwareService.SelectAll();
            return Ok(hardwareList);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("ExibirUsuarioPorId")]
    public async Task<ActionResult> SelectHardware(int id)
    {
        try
        {

            var hardware = await _hardwareService.SelectByPk(id);
            return Ok(hardware);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
