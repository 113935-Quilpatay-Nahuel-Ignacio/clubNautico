using ApiClubNautico.Data;
using ApiClubNautico.Models;
using ApiClubNautico.Validations.Socios;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiClubNautico.Business.SocioBusiness.Queries
{
    public class GetSocioByIdQuery : IRequest<Socio>
    {
        public int Id { get; set; }
    }

    public class GetSocioByIdHandler : IRequestHandler<GetSocioByIdQuery, Socio>
    {
        private readonly ApplicationContext _context;
        private readonly GetSocioByIdQueryValidation _validation;

        public GetSocioByIdHandler(ApplicationContext context, GetSocioByIdQueryValidation validation)
        {
            _context = context;
            _validation = validation;
        }

        public async Task<Socio> Handle(GetSocioByIdQuery request, CancellationToken cancellationToken)
        {
            _validation.Validate(request);
            try
            {
                var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == request.Id);
                if (socio != null)
                {
                    return socio;
                }
                else
                {
                    throw new ArgumentNullException(nameof(socio));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
