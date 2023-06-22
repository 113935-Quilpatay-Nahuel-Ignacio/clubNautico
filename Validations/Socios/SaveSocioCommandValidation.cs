using ApiClubNautico.Business.SocioBusiness.Commands;
using FluentValidation;

namespace ApiClubNautico.Validations.Socios
{

    public class SaveSocioCommandValidation : AbstractValidator<SaveSocioCommand>
    {
        public SaveSocioCommandValidation()
        {
            RuleFor(s => s.Nombre).NotEmpty();
            RuleFor(s => s.Apellido).NotEmpty();
            RuleFor(s => s.Telefono).NotEmpty();
        }
    }
}
