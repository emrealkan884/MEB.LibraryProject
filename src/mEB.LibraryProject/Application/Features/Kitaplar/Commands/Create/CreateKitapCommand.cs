using Application.Features.Eserler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Application.Services.KitapBaskilar;
using Domain.Enums;
using MediatR;


public class CreateKitapCommand : IRequest<CreatedKitapResponse>
{
    public required string Adi { get; set; }
    public required string DilKodu { get; set; }
    public string? Aciklama { get; set; }
    public required string DeweyKodu { get; set; }
    public required string MarcVerisi { get; set; }
    public required Guid YayinEviId { get; set; }
    public required string ISBN {get;set;}
    public required ICollection<Guid> YazarIdler { get; set; }
    public required EserKategorisi Kategori { get; set; }
    public string? SayfaSayisi  { get; set; }
    public short? BasimYili {get;set;}
    public string? BasimYeri {get;set;}
    public string? BaskiBilgisi  {get;set;}
 
    public class CreateKitapCommandHandler : IRequestHandler<CreateKitapCommand,CreatedKitapResponse>
    {
        private readonly IMapper _mapper;
        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapBaskiService _kitapBaskiService;
        private readonly EserBusinessRules _kitapBusinessRules;

        public CreateKitapCommandHandler(IMapper mapper, IKitapRepository kitapRepository, IKitapBaskiService kitapBaskiService, EserBusinessRules kitapBusinessRules)
        {
            _mapper = mapper;
            _kitapRepository = kitapRepository;
            _kitapBaskiService = kitapBaskiService;
            _kitapBusinessRules = kitapBusinessRules;
        }

        public async Task<CreatedKitapResponse> Handle(CreateKitapCommand request, CancellationToken cancellationToken)
        {
            Kitap kitap = _mapper.Map<Kitap>(request);
            
            if (request.YazarIdler is not null)
            {
                foreach (var yazarId in request.YazarIdler)
                    kitap.Yazarlar.Add(new EserYazar(yazarId, kitap.Id));
            }

            await _kitapRepository.AddAsync(kitap);

            // Normalize & validate ISBN then create initial edition (KitapBaski)
            await _kitapBaskiService.CreateAsync(kitap, request.YayinEviId, request.ISBN, request.SayfaSayisi, request.BasimYili, request.BasimYeri, request.BaskiBilgisi, null);

            CreatedKitapResponse response = _mapper.Map<CreatedKitapResponse>(kitap);
            return response;
        }
    }
}