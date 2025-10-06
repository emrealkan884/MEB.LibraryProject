using Application.Features.Konums.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Konums.Queries.GetById;

public class GetByIdKonumQuery : IRequest<GetByIdKonumResponse>
{
    public Guid Id { get; set; }

    public class GetByIdKonumQueryHandler : IRequestHandler<GetByIdKonumQuery, GetByIdKonumResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKonumRepository _konumRepository;
        private readonly KonumBusinessRules _konumBusinessRules;

        public GetByIdKonumQueryHandler(IMapper mapper, IKonumRepository konumRepository, KonumBusinessRules konumBusinessRules)
        {
            _mapper = mapper;
            _konumRepository = konumRepository;
            _konumBusinessRules = konumBusinessRules;
        }

        public async Task<GetByIdKonumResponse> Handle(GetByIdKonumQuery request, CancellationToken cancellationToken)
        {
            Konum? konum = await _konumRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _konumBusinessRules.KonumShouldExistWhenSelected(konum);

            GetByIdKonumResponse response = _mapper.Map<GetByIdKonumResponse>(konum);
            return response;
        }
    }
}