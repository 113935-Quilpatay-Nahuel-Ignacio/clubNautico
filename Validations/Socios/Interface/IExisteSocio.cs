using ApiClubNautico.Models;

namespace ApiClubNautico.Validations.Socios.Interface
{
    public interface IExisteSocio
    {
        Task Validar(Socio socio);
    }
}
