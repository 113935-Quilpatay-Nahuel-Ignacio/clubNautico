using ApiClubNautico.Services.SocioService.Commands;
using FluentValidation;

namespace ApiClubNautico.Validations.Socios
{
    public class UpdateSocioCommandValidation : AbstractValidator<UpdateSocioCommand>
    {
        public UpdateSocioCommandValidation()
        {
            RuleFor(s => s.Id).NotEmpty();
            RuleFor(s => s.Nombre).NotEmpty();
            RuleFor(s => s.Apellido).NotEmpty();
            RuleFor(s => s.Telefono).NotEmpty();
        }
    }
}
