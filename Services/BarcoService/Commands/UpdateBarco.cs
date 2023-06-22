using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Barcos;
using ApiClubNautico.Validations.Socios;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Services.BarcoService.Commands
{
    public class UpdateBarcoCommand : IRequest<Barco>
    {
        public int Id { get; set; }
        public int IdSocio { get; set; }

        public int NumMatricula { get; set; }

        public string Nombre { get; set; } = null!;

        public int NumAmarre { get; set; }

        public double Cuota { get; set; }
    }

    public class UpdateBarcoHandler : IRequestHandler<UpdateBarcoCommand, Barco>
    {
        private readonly ApplicationContext _context;
        private readonly UpdateBarcoCommandValidation _validation;

        public UpdateBarcoHandler(ApplicationContext context, UpdateBarcoCommandValidation validation)
        {
            _context = context;
            _validation = validation;
        }

        public async Task<Barco> Handle(UpdateBarcoCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);
            try
            {
                var barco = await _context.Barcos.FirstOrDefaultAsync(b => b.Id == request.Id);
                if (barco != null)
                {
                    barco.NumMatricula = request.NumMatricula;
                    barco.Nombre = request.Nombre;
                    barco.NumAmarre = request.NumAmarre;
                    barco.Cuota = request.Cuota;

                    await _context.SaveChangesAsync();

                    return barco;
                }
                else
                {
                    throw new ArgumentNullException(nameof(barco));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
