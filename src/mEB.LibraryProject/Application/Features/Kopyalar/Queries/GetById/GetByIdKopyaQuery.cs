using Application.Features.Kopyalar.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Kopyalar.Queries.GetById;

public class GetByIdKopyaQuery : IRequest<GetByIdKopyaResponse>
{
    public Guid Id { get; set; }

    public class GetByIdKopyaQueryHandler : IRequestHandler<GetByIdKopyaQuery, GetByIdKopyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaRepository _kopyaRepository;
        private readonly KopyaBusinessRules _kopyaBusinessRules;

        public GetByIdKopyaQueryHandler(IMapper mapper, IKopyaRepository kopyaRepository, KopyaBusinessRules kopyaBusinessRules)
        {
            _mapper = mapper;
            _kopyaRepository = kopyaRepository;
            _kopyaBusinessRules = kopyaBusinessRules;
        }

        public async Task<GetByIdKopyaResponse> Handle(GetByIdKopyaQuery request, CancellationToken cancellationToken)
        {
            Kopya? kopya = await _kopyaRepository.GetAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            await _kopyaBusinessRules.KopyaShouldExistWhenSelected(kopya);

            GetByIdKopyaResponse response = _mapper.Map<GetByIdKopyaResponse>(kopya);
            return response;
        }
    }
}