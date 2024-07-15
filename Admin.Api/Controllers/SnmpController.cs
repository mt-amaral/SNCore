﻿using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Share.Request;
using Admin.Share.Response;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace ConnectionControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SnmpController : Controller
{
    private readonly ISnmpService _snmpService;

    public SnmpController(ISnmpService snmpService)
    {
        _snmpService = snmpService;
    }
    [HttpGet]
    [Route("ExibirSnmpPorId")]
    public async Task<ActionResult> SelectSnmp(int id)
    {
        try
        {
            var snmp = await _snmpService.SelectByPk(id);
            return Ok(snmp);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    [Route("ExibirSnmpPorHardwareId")]

    public ActionResult<SnmpResponse> SelectByHardware(int id)
    {
        try
        {
            var snmp =  _snmpService.SnmpSelectByHarware(id);
            return Ok(snmp);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("CriarSnmp")]
    public async Task<ActionResult> CreateSnmp(SnmpRequest SnmpNew)
    {
        try
        {
            await _snmpService.Create(SnmpNew);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    [Route("EditarSnmp")]
    public async Task<ActionResult> EditSnmp(SnmpRequest snmpRequest)
    {
        try
        {
            await _snmpService.Edit(snmpRequest);
            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete]
    [Route("DeleteSnmp")]
    public async Task<ActionResult> DeleteHardware(int snmpId)
    {
        try
        {
            await _snmpService.Delete(snmpId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
