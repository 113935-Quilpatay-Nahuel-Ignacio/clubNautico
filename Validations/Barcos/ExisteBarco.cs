using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Barcos.Interface;
using ApiClubNautico.Validations.Socios.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Validations.Barcos
{
    public class ExisteBarco : IExisteBarco
    {
        private readonly ApplicationContext _context;
        public ExisteBarco(ApplicationContext context)
        {
            _context = context;
        }

        public async Task Validar(Barco barco)
        {
            bool existeBarco = await _context.Barcos.AnyAsync(b => b.Nombre == barco.Nombre);

            if (existeBarco)
            {
                throw new Exception("El barco ya existe.");
            }
        }
    }
}
