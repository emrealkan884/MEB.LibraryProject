using Application.Features.EserYazars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.EserYazars.Queries.GetById;

public class GetByIdEserYazarQuery : IRequest<GetByIdEserYazarResponse>
{
    public Guid Id { get; set; }

    public class GetByIdEserYazarQueryHandler : IRequestHandler<GetByIdEserYazarQuery, GetByIdEserYazarResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEserYazarRepository _eserYazarRepository;
        private readonly EserYazarBusinessRules _eserYazarBusinessRules;

        public GetByIdEserYazarQueryHandler(IMapper mapper, IEserYazarRepository eserYazarRepository, EserYazarBusinessRules eserYazarBusinessRules)
        {
            _mapper = mapper;
            _eserYazarRepository = eserYazarRepository;
            _eserYazarBusinessRules = eserYazarBusinessRules;
        }

        public async Task<GetByIdEserYazarResponse> Handle(GetByIdEserYazarQuery request, CancellationToken cancellationToken)
        {
            EserYazar? eserYazar = await _eserYazarRepository.GetAsync(predicate: ey => ey.Id == request.Id, cancellationToken: cancellationToken);
            await _eserYazarBusinessRules.EserYazarShouldExistWhenSelected(eserYazar);

            GetByIdEserYazarResponse response = _mapper.Map<GetByIdEserYazarResponse>(eserYazar);
            return response;
        }
    }
}