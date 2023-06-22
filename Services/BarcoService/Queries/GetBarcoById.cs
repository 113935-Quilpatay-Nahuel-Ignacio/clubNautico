using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Barcos;
using ApiClubNautico.Validations.Socios;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Services.BarcoService.Queries
{
    public class GetBarcoByIdQuery : IRequest<Barco>
    {
        public int Id { get; set; }
    }

    public class GetBarcoByIdHandler : IRequestHandler<GetBarcoByIdQuery, Barco>
    {
        private readonly ApplicationContext _context;
        private readonly GetBarcoByIdQueryValidation _validation;

        public GetBarcoByIdHandler(ApplicationContext context, GetBarcoByIdQueryValidation validation)
        {
            _context = context;
            _validation = validation;
        }

        public async Task<Barco> Handle(GetBarcoByIdQuery request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);
            try
            {
                var barco = await _context.Barcos.FirstOrDefaultAsync(s => s.Id == request.Id);
                if (barco != null)
                {
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
