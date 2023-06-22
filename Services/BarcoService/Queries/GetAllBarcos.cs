using ApiClubNautico.Data;
using ApiClubNautico.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Services.BarcoService.Queries
{
    public class GetAllBarcosQuery : IRequest<List<Barco>>
    {
    }

    public class GetAllBarcosQueryHandler : IRequestHandler<GetAllBarcosQuery, List<Barco>>
    {
        private readonly ApplicationContext _context;

        public GetAllBarcosQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Barco>> Handle(GetAllBarcosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var barcos = await _context.Barcos.ToListAsync();
                if (barcos.Count != 0)
                {
                    return barcos;
                }
                else
                {
                    throw new Exception("No existen barcos en la base de datos.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
