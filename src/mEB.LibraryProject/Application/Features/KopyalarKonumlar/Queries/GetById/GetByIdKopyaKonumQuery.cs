using Application.Features.KopyalarKonumlar.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.KopyalarKonumlar.Queries.GetById;

public class GetByIdKopyaKonumQuery : IRequest<GetByIdKopyaKonumResponse>
{
    public Guid Id { get; set; }

    public class GetByIdKopyaKonumQueryHandler : IRequestHandler<GetByIdKopyaKonumQuery, GetByIdKopyaKonumResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaKonumRepository _kopyaKonumRepository;
        private readonly KopyaKonumBusinessRules _kopyaKonumBusinessRules;

        public GetByIdKopyaKonumQueryHandler(IMapper mapper, IKopyaKonumRepository kopyaKonumRepository, KopyaKonumBusinessRules kopyaKonumBusinessRules)
        {
            _mapper = mapper;
            _kopyaKonumRepository = kopyaKonumRepository;
            _kopyaKonumBusinessRules = kopyaKonumBusinessRules;
        }

        public async Task<GetByIdKopyaKonumResponse> Handle(GetByIdKopyaKonumQuery request, CancellationToken cancellationToken)
        {
            KopyaKonum? kopyaKonum = await _kopyaKonumRepository.GetAsync(predicate: kk => kk.Id == request.Id, cancellationToken: cancellationToken);
            await _kopyaKonumBusinessRules.KopyaKonumShouldExistWhenSelected(kopyaKonum);

            GetByIdKopyaKonumResponse response = _mapper.Map<GetByIdKopyaKonumResponse>(kopyaKonum);
            return response;
        }
    }
}