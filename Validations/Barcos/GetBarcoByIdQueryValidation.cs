using ApiClubNautico.Services.BarcoService.Queries;
using FluentValidation;

namespace ApiClubNautico.Validations.Barcos
{
    public class GetBarcoByIdQueryValidation : AbstractValidator<GetBarcoByIdQuery>
    {
        public GetBarcoByIdQueryValidation()
        {
            RuleFor(b => b.Id).NotEmpty();
        }
    }
}
