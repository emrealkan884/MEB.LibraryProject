using Application.Services.Repositories;
using AutoMapper;
using MediatR;

public class UpdateKitapCommand : IRequest<UpdatedKitapResponse>
{
    public Guid Id { get; set; }
    public required string Adi { get; set; }
    public required string DilKodu { get; set; }
    public required string Aciklama { get; set; }
    public string? DeweyKodu { get; set; }
    public string? MarcVerisi { get; set; }

    public class UpdateKitapCommandHandler : IRequestHandler<UpdateKitapCommand, UpdatedKitapResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKitapRepository _kitapRepository;
        private readonly KitapBusinessRules _kitapBusinessRules;

        public UpdateKitapCommandHandler(IMapper mapper, IKitapRepository kitapRepository, KitapBusinessRules kitapBusinessRules)
        {
            _mapper = mapper;
            _kitapRepository = kitapRepository;
            _kitapBusinessRules = kitapBusinessRules;
        }

        public async Task<UpdatedKitapResponse> Handle(UpdateKitapCommand request, CancellationToken cancellationToken)
        {
            Kitap? kitap = await _kitapRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _kitapBusinessRules.KitapShouldExistWhenSelected(kitap);
            kitap = _mapper.Map(request, kitap);

            await _kitapRepository.UpdateAsync(kitap!);

            UpdatedKitapResponse response = _mapper.Map<UpdatedKitapResponse>(kitap);
            return response;
        }
    }
}