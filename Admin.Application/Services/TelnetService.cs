

using Admin.Share.Response;
using Admin.Share.Request;
using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using AutoMapper;

namespace Admin.Application.Services;

public class TelnetService : BaseService<Telnet, TelnetRequest, TelnetResponse, ITelnetRepository>, ITelnetService
{
    public TelnetService(ITelnetRepository telnetRepository, IMapper mapper)
        : base(telnetRepository, mapper)
    {
    }
}
