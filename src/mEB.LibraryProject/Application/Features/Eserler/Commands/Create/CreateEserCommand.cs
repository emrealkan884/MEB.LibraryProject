using Application.Features.Eserler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Eserler.Commands.Create;

public class CreateEserCommand : IRequest<CreatedEserResponse>
{
    public required string Adi { get; set; }
    public required string DilKodu { get; set; }
    public required string Aciklama { get; set; }
    public string? DeweyKodu { get; set; }
    public string? MarcVerisi { get; set; }

    public class CreateEserCommandHandler : IRequestHandler<CreateEserCommand, CreatedEserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEserRepository _eserRepository;
        private readonly EserBusinessRules _eserBusinessRules;

        public CreateEserCommandHandler(IMapper mapper, IEserRepository eserRepository,
                                         EserBusinessRules eserBusinessRules)
        {
            _mapper = mapper;
            _eserRepository = eserRepository;
            _eserBusinessRules = eserBusinessRules;
        }

        public async Task<CreatedEserResponse> Handle(CreateEserCommand request, CancellationToken cancellationToken)
        {
            Eser eser = _mapper.Map<Eser>(request);

            await _eserRepository.AddAsync(eser);

            CreatedEserResponse response = _mapper.Map<CreatedEserResponse>(eser);
            return response;
        }
    }
}