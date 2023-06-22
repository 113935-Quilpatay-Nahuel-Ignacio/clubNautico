using ApiClubNautico.Services.SocioService.Commands;
using FluentValidation;

namespace ApiClubNautico.Validations.Socios
{
    public class DeleteSocioCommandValidation : AbstractValidator<DeleteSocioCommand>
    {
        public DeleteSocioCommandValidation()
        {
            RuleFor(s => s.Id).NotEmpty();
        }
    }
}
