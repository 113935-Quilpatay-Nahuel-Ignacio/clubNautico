using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Socios.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Validations.Socios
{
    public class ExisteSocio : IExisteSocio
    {
        private readonly ApplicationContext _context;
        public ExisteSocio(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Validar(Socio socio)
        {
            bool existeSocio = await _context.Socios.AnyAsync(s => s.Nombre == socio.Nombre /*&& s.Apellido == socio.Apellido*/);

            if (existeSocio)
            {
                throw new Exception("El socio ya existe.");
            }
        }
    }
}
