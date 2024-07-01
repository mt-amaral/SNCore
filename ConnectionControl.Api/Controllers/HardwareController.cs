using ConnectionControl.Application.Dtos;
using ConnectionControl.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HardwareController : Controller
{
    private readonly IHardwareService _hardwareService;

    public HardwareController(IHardwareService hardwareService)
    {
        _hardwareService = hardwareService;
    }

    [HttpGet]
    [Route("ExibirTodos")]
    public async Task<ActionResult<IEnumerable<HardwareDto>>> GetHardware()
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
    public async Task<ActionResult> CreateHardware(HardwareDto hardwareNew)
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
    public async Task<ActionResult> EditHardware(HardwareDto hardwareRequest)
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
    [HttpGet]
    [Route("TesteSNMP")]
    public async Task<ActionResult> TesteSNMP()
    {
        try
        {
            await _hardwareService.TesteSNPM();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
