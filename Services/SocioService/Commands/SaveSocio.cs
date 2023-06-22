using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Socios;
using ApiClubNautico.Validations.Socios.Interface;
using FluentValidation;
using MediatR;

namespace ApiClubNautico.Business.SocioBusiness.Commands
{
    public class SaveSocioCommand : IRequest<Socio>
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Telefono { get; set; } = null!;
    }

    public class SaveSocioHandler : IRequestHandler<SaveSocioCommand, Socio>
    {
        private readonly ApplicationContext _context;
        private readonly SaveSocioCommandValidation _validation;
        private readonly IExisteSocio _existeSocio;
        public SaveSocioHandler(ApplicationContext context, SaveSocioCommandValidation validation, IExisteSocio existeSocio)
        {
            _context = context;
            _validation = validation;
            _existeSocio = existeSocio;
        }

        public async Task<Socio> Handle(SaveSocioCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);
            try
            {
                Socio socio = new Socio();
                socio.Nombre = request.Nombre;
                socio.Apellido = request.Apellido;
                socio.Telefono = request.Telefono;

                await _existeSocio.Validar(socio);

                await _context.Socios.AddAsync(socio);
                await _context.SaveChangesAsync();

                return socio;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
