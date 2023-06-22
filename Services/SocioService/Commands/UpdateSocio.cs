using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Socios;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Services.SocioService.Commands
{
    public class UpdateSocioCommand : IRequest<Socio>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
    }

    public class UpdateSocioHandler : IRequestHandler<UpdateSocioCommand, Socio>
    {
        private readonly ApplicationContext _context;
        private readonly UpdateSocioCommandValidation _validation;

        public UpdateSocioHandler(ApplicationContext context, UpdateSocioCommandValidation validation)
        {
            _context = context;
            _validation = validation;
        }

        public async Task<Socio> Handle(UpdateSocioCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);
            try
            {
                var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == request.Id);
                if (socio != null)
                {
                    socio.Nombre = request.Nombre;
                    socio.Apellido = request.Apellido;
                    socio.Telefono = request.Telefono;

                    await _context.SaveChangesAsync();

                    return socio;
                }
                else
                {
                    throw new ArgumentNullException(nameof(socio));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
