using Application.Features.KopyalarKonumlar.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.KopyalarKonumlar.Commands.Create;

public class CreateKopyaKonumCommand : IRequest<CreatedKopyaKonumResponse>
{
    public required Guid KopyaId { get; set; }
    public required Guid KonumId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public required int Adet { get; set; }

    public class CreateKopyaKonumCommandHandler : IRequestHandler<CreateKopyaKonumCommand, CreatedKopyaKonumResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaKonumRepository _kopyaKonumRepository;
        private readonly KopyaKonumBusinessRules _kopyaKonumBusinessRules;

        public CreateKopyaKonumCommandHandler(IMapper mapper, IKopyaKonumRepository kopyaKonumRepository,
                                         KopyaKonumBusinessRules kopyaKonumBusinessRules)
        {
            _mapper = mapper;
            _kopyaKonumRepository = kopyaKonumRepository;
            _kopyaKonumBusinessRules = kopyaKonumBusinessRules;
        }

        public async Task<CreatedKopyaKonumResponse> Handle(CreateKopyaKonumCommand request, CancellationToken cancellationToken)
        {
            KopyaKonum kopyaKonum = _mapper.Map<KopyaKonum>(request);

            await _kopyaKonumRepository.AddAsync(kopyaKonum);

            CreatedKopyaKonumResponse response = _mapper.Map<CreatedKopyaKonumResponse>(kopyaKonum);
            return response;
        }
    }
}