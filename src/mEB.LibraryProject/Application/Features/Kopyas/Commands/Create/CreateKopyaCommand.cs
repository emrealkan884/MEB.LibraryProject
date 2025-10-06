using Application.Features.Kopyas.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Kopyas.Commands.Create;

public class CreateKopyaCommand : IRequest<CreatedKopyaResponse>
{
    public required Guid KitapId { get; set; }
    public required Guid KutuphaneId { get; set; }
    public required string Barkod { get; set; }

    public class CreateKopyaCommandHandler : IRequestHandler<CreateKopyaCommand, CreatedKopyaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKopyaRepository _kopyaRepository;
        private readonly KopyaBusinessRules _kopyaBusinessRules;

        public CreateKopyaCommandHandler(IMapper mapper, IKopyaRepository kopyaRepository,
                                         KopyaBusinessRules kopyaBusinessRules)
        {
            _mapper = mapper;
            _kopyaRepository = kopyaRepository;
            _kopyaBusinessRules = kopyaBusinessRules;
        }

        public async Task<CreatedKopyaResponse> Handle(CreateKopyaCommand request, CancellationToken cancellationToken)
        {
            Kopya kopya = _mapper.Map<Kopya>(request);

            await _kopyaRepository.AddAsync(kopya);

            CreatedKopyaResponse response = _mapper.Map<CreatedKopyaResponse>(kopya);
            return response;
        }
    }
}