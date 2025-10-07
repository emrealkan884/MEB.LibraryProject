using Application.Features.Oduncler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Oduncler.Queries.GetById;

public class GetByIdOduncQuery : IRequest<GetByIdOduncResponse>
{
    public Guid Id { get; set; }

    public class GetByIdOduncQueryHandler : IRequestHandler<GetByIdOduncQuery, GetByIdOduncResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOduncRepository _oduncRepository;
        private readonly OduncBusinessRules _oduncBusinessRules;

        public GetByIdOduncQueryHandler(IMapper mapper, IOduncRepository oduncRepository, OduncBusinessRules oduncBusinessRules)
        {
            _mapper = mapper;
            _oduncRepository = oduncRepository;
            _oduncBusinessRules = oduncBusinessRules;
        }

        public async Task<GetByIdOduncResponse> Handle(GetByIdOduncQuery request, CancellationToken cancellationToken)
        {
            Odunc? odunc = await _oduncRepository.GetAsync(predicate: o => o.Id == request.Id, cancellationToken: cancellationToken);
            await _oduncBusinessRules.OduncShouldExistWhenSelected(odunc);

            GetByIdOduncResponse response = _mapper.Map<GetByIdOduncResponse>(odunc);
            return response;
        }
    }
}