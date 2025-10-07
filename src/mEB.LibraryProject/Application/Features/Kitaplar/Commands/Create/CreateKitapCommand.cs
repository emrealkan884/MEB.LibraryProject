using Application.Features.Eserler.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;


public class CreateKitapCommand : IRequest<CreatedKitapResponse>
{
    public required string Adi { get; set; }
    public required string DilKodu { get; set; }
    public string? Aciklama { get; set; }
    public required string DeweyKodu { get; set; }
    public required string MarcVerisi { get; set; }
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
        private readonly EserBusinessRules _kitapBusinessRules;

        public CreateKitapCommandHandler(IMapper mapper, IKitapRepository kitapRepository, EserBusinessRules kitapBusinessRules)
        {
            _mapper = mapper;
            _kitapRepository = kitapRepository;
            _kitapBusinessRules = kitapBusinessRules;
        }

        public async Task<CreatedKitapResponse> Handle(CreateKitapCommand request, CancellationToken cancellationToken)
        {
            Kitap kitap = _mapper.Map<Kitap>(request);
            
            if (request.YazarIdler is not null)
            {
                foreach (var yazarId in request.YazarIdler)
                    kitap.EserlerYazarlar.Add(new EserYazar(yazarId, kitap.Id));
            }

            await _kitapRepository.AddAsync(kitap);

            CreatedKitapResponse response = _mapper.Map<CreatedKitapResponse>(kitap);
            return response;
        }
    }
}