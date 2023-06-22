using ApiClubNautico.Business.SocioBusiness.Queries;
using FluentValidation;

namespace ApiClubNautico.Validations.Socios
{
    public class GetSocioByIdQueryValidation : AbstractValidator<GetSocioByIdQuery>
    {
        public GetSocioByIdQueryValidation()
        {
            RuleFor(g => g.Id).NotEmpty();
        }
    }
}
