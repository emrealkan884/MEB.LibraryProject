using Application.Features.Esers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Esers.Queries.GetById;

public class GetByIdEserQuery : IRequest<GetByIdEserResponse>
{
    public Guid Id { get; set; }

    public class GetByIdEserQueryHandler : IRequestHandler<GetByIdEserQuery, GetByIdEserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEserRepository _eserRepository;
        private readonly EserBusinessRules _eserBusinessRules;

        public GetByIdEserQueryHandler(IMapper mapper, IEserRepository eserRepository, EserBusinessRules eserBusinessRules)
        {
            _mapper = mapper;
            _eserRepository = eserRepository;
            _eserBusinessRules = eserBusinessRules;
        }

        public async Task<GetByIdEserResponse> Handle(GetByIdEserQuery request, CancellationToken cancellationToken)
        {
            Eser? eser = await _eserRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _eserBusinessRules.EserShouldExistWhenSelected(eser);

            GetByIdEserResponse response = _mapper.Map<GetByIdEserResponse>(eser);
            return response;
        }
    }
}