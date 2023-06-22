using ApiClubNautico.Services.BarcoService.Commands;
using FluentValidation;

namespace ApiClubNautico.Validations.Barcos
{
    public class UpdateBarcoCommandValidation : AbstractValidator<UpdateBarcoCommand>
    {
        public UpdateBarcoCommandValidation() 
        {
            RuleFor(b => b.Id).NotEmpty();
            RuleFor(b => b.IdSocio).NotEmpty();
            RuleFor(b => b.NumMatricula).NotEmpty();
            RuleFor(b => b.NumAmarre).NotEmpty();
            RuleFor(b => b.Nombre).NotEmpty();
            RuleFor(b => b.Cuota).NotEmpty();
        }
    }
}
