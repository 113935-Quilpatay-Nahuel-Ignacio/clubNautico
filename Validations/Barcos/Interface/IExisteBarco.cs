using ApiClubNautico.Models;

namespace ApiClubNautico.Validations.Barcos.Interface
{
    public interface IExisteBarco
    {
        Task Validar(Barco barco);
    }
}
