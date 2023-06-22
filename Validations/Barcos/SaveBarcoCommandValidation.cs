using ApiClubNautico.Business.SocioBusiness.Commands;
using ApiClubNautico.Services.BarcoService.Commands;
using FluentValidation;

namespace ApiClubNautico.Validations.Barcos
{
    public class SaveBarcoCommandValidation : AbstractValidator<SaveBarcoCommand>
    {
        public SaveBarcoCommandValidation()
        {
            RuleFor(b => b.IdSocio).NotEmpty();
            RuleFor(b => b.NumMatricula).NotEmpty();
            RuleFor(b => b.NumAmarre).NotEmpty();
            RuleFor(b => b.Nombre).NotEmpty();
            RuleFor(b => b.Cuota).NotEmpty();
        }
    }
}
