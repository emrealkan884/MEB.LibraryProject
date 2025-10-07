using Application.Features.Eserler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Eserler.Commands.Update;

public class UpdateEserCommand : IRequest<UpdatedEserResponse>
{
    public Guid Id { get; set; }
    public required string Adi { get; set; }
    public required string DilKodu { get; set; }
    public required string Aciklama { get; set; }
    public string? DeweyKodu { get; set; }
    public string? MarcVerisi { get; set; }

    public class UpdateEserCommandHandler : IRequestHandler<UpdateEserCommand, UpdatedEserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEserRepository _eserRepository;
        private readonly EserBusinessRules _eserBusinessRules;

        public UpdateEserCommandHandler(IMapper mapper, IEserRepository eserRepository,
                                         EserBusinessRules eserBusinessRules)
        {
            _mapper = mapper;
            _eserRepository = eserRepository;
            _eserBusinessRules = eserBusinessRules;
        }

        public async Task<UpdatedEserResponse> Handle(UpdateEserCommand request, CancellationToken cancellationToken)
        {
            Eser? eser = await _eserRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _eserBusinessRules.EserShouldExistWhenSelected(eser);
            eser = _mapper.Map(request, eser);

            await _eserRepository.UpdateAsync(eser!);

            UpdatedEserResponse response = _mapper.Map<UpdatedEserResponse>(eser);
            return response;
        }
    }
}