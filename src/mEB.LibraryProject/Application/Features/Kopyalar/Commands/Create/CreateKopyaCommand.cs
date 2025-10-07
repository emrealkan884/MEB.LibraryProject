using Application.Features.Kopyalar.Rules;
using Application.Services.Kopyalar;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Kopyalar.Commands.Create;

public class CreateKopyaCommand : IRequest<CreatedKopyaResponse>
{
    public required Guid KitapId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public required int Count { get; set; }
    public required string Barkod { get; set; }

    public class CreateKopyaCommandHandler : IRequestHandler<CreateKopyaCommand, CreatedKopyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaRepository _kopyaRepository;
        private readonly KopyaBusinessRules _kopyaBusinessRules;
        private readonly IKopyaService _kopyaService;

        public CreateKopyaCommandHandler(IMapper mapper, IKopyaRepository kopyaRepository,
                                         KopyaBusinessRules kopyaBusinessRules, IKopyaService kopyaService)
        {
            _mapper = mapper;
            _kopyaRepository = kopyaRepository;
            _kopyaBusinessRules = kopyaBusinessRules;
            _kopyaService  = kopyaService;
        }

        public async Task<CreatedKopyaResponse> Handle(CreateKopyaCommand request, CancellationToken cancellationToken)
        {
            // Command -> Domain entity
            Kopya kopya = _mapper.Map<Kopya>(request);

            // İş mantığı: varsa artır, yoksa ekle
            Kopya result = await _kopyaService.AddOrIncrementAsync(kopya);

            // Entity -> Response
            CreatedKopyaResponse response = _mapper.Map<CreatedKopyaResponse>(result);
            return response;
        }
    }
}