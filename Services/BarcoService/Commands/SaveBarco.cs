using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Socios.Interface;
using ApiClubNautico.Validations.Socios;
using MediatR;
using ApiClubNautico.Validations.Barcos;
using ApiClubNautico.Validations.Barcos.Interface;

namespace ApiClubNautico.Services.BarcoService.Commands
{
    public class SaveBarcoCommand : IRequest<Barco>
    {
        public int IdSocio { get; set; }

        public int NumMatricula { get; set; }

        public string Nombre { get; set; } = null!;

        public int NumAmarre { get; set; }

        public double Cuota { get; set; }
    }

    public class SaveBarcoHandler : IRequestHandler<SaveBarcoCommand, Barco>
    {
        private readonly ApplicationContext _context;
        private readonly SaveBarcoCommandValidation _validation;
        private readonly IExisteBarco _existeBarco;
        public SaveBarcoHandler(ApplicationContext context, SaveBarcoCommandValidation validation, IExisteBarco existeBarco)
        {
            _context = context;
            _validation = validation;
            _existeBarco = existeBarco;
        }

        public async Task<Barco> Handle(SaveBarcoCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);
            try
            {
                Barco barco = new Barco();
                barco.IdSocio = request.IdSocio;
                barco.NumMatricula = request.NumMatricula;
                barco.Nombre = request.Nombre;
                barco.NumAmarre = request.NumAmarre;
                barco.Cuota = request.Cuota;

                await _existeBarco.Validar(barco);

                await _context.Barcos.AddAsync(barco);
                await _context.SaveChangesAsync();

                return barco;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
