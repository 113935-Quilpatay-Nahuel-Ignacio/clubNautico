using ApiClubNautico.Services.BarcoService.Commands;
using ApiClubNautico.Services.SocioService.Commands;
using FluentValidation;

namespace ApiClubNautico.Validations.Barcos
{
    public class DeleteBarcoCommandValidation : AbstractValidator<DeleteBarcoCommand>
    {
        public DeleteBarcoCommandValidation()
        {
            RuleFor(b => b.Id).NotEmpty();
        }
    }
}
