using ApiClubNautico.Data;
using ApiClubNautico.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Services.SocioService.Queries
{
    public class GetAllSociosQuery : IRequest<List<Socio>>
    {
    }

    public class GetAllSociosQueryHandler : IRequestHandler<GetAllSociosQuery, List<Socio>>
    {
        private readonly ApplicationContext _context;
        
        public GetAllSociosQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Socio>> Handle(GetAllSociosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Uso de LINQ (consultas con EntityFramework)
                //var socios = await _context.Socios.Where(s => s.Nombre.StartsWith("j")).ToListAsync();
                var socios = await _context.Socios.Where(s => s.Nombre.StartsWith("j")).ToListAsync();
                if (socios.Count != 0)
                {
                    return socios;
                }
                else
                {
                    throw new Exception("No existen socios en la base de datos.");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
