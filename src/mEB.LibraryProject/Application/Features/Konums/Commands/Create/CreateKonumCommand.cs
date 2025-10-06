using Application.Features.Konums.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Domain.Enums;

namespace Application.Features.Konums.Commands.Create;

public class CreateKonumCommand : IRequest<CreatedKonumResponse>
{
    public required Guid KutuphaneId { get; set; }
    public Guid? UstKonumId { get; set; }
    public required KonumTip KonumTip { get; set; }
    public required string Ad { get; set; }

    public class CreateKonumCommandHandler : IRequestHandler<CreateKonumCommand, CreatedKonumResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKonumRepository _konumRepository;
        private readonly KonumBusinessRules _konumBusinessRules;

        public CreateKonumCommandHandler(IMapper mapper, IKonumRepository konumRepository,
                                         KonumBusinessRules konumBusinessRules)
        {
            _mapper = mapper;
            _konumRepository = konumRepository;
            _konumBusinessRules = konumBusinessRules;
        }

        public async Task<CreatedKonumResponse> Handle(CreateKonumCommand request, CancellationToken cancellationToken)
        {
            Konum konum = _mapper.Map<Konum>(request);

            await _konumRepository.AddAsync(konum);

            CreatedKonumResponse response = _mapper.Map<CreatedKonumResponse>(konum);
            return response;
        }
    }
}