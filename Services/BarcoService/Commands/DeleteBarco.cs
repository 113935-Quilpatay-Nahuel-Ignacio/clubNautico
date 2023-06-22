using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Barcos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Services.BarcoService.Commands
{
    public class DeleteBarcoCommand : IRequest<Barco>
    {
        public int Id { get; set; }
    }

    public class DeleteBarcoHandler : IRequestHandler<DeleteBarcoCommand, Barco>
    {
        private readonly ApplicationContext _context;
        private readonly DeleteBarcoCommandValidation _validation;

        public DeleteBarcoHandler(ApplicationContext context, DeleteBarcoCommandValidation validation)
        {
            _context = context;
            _validation = validation;
        }

        public async Task<Barco> Handle(DeleteBarcoCommand request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);
            try
            {
                var barco = await _context.Barcos.FirstOrDefaultAsync(b => b.Id == request.Id);
                if (barco != null)
                {
                    _context.Barcos.Remove(barco);

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
