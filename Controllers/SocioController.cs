using ApiClubNautico.Business.SocioBusiness.Commands;
using ApiClubNautico.Business.SocioBusiness.Queries;
using ApiClubNautico.Models;
using ApiClubNautico.Services.SocioService.Commands;
using ApiClubNautico.Services.SocioService.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClubNautico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SocioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("save")]
        public async Task<Socio> SaveSocio([FromBody] SaveSocioCommand saveSocioCommand)
        {
            return await _mediator.Send(saveSocioCommand);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        public async Task<Socio> GetSocioById(int id)
        {
            return await _mediator.Send(new GetSocioByIdQuery { Id = id });
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<List<Socio>> GetSocios()
        {
            return await _mediator.Send(new GetAllSociosQuery());
        }

        [HttpPut]
        [Route("update")]
        public async Task<Socio> UpdateSocio([FromBody] UpdateSocioCommand updateSocioCommand)
        {
            return await _mediator.Send(updateSocioCommand);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<Socio> DeleteSocio(int id)
        {
            return await _mediator.Send(new DeleteSocioCommand { Id = id });
        }
    }
}
