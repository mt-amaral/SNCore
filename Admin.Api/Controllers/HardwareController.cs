
using Admin.Application.Interfaces;
using Admin.Share.Request;
using Admin.Share.Response;
using AutoMapper;
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
    public async Task<ActionResult<IEnumerable<HardwareResponse>>> GetHardware()
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
    [HttpPost]
    [Route("CriarHardware")]
    public async Task<ActionResult> CreateHardware(HardwareRequest hardwareNew)
    {
        try
        {
            await _hardwareService.Create(hardwareNew);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    [Route("EditarHardware")]
    public async Task<ActionResult> EditHardware(HardwareRequest hardwareRequest)
    {
        try
        {
            await _hardwareService.Edit(hardwareRequest);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("DeleteHardware")]
    public async Task<ActionResult> DeleteHardware(int hardwareId)
    {
        try
        {
            await _hardwareService.Delete(hardwareId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
