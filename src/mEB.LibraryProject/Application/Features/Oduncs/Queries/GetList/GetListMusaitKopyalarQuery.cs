using Application.Features.Oduncs.Queries.Dtos;
using Application.Services.Repositories;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Oduncs.Queries.GetList;

public class GetListMusaitKopyalarQuery : IRequest<List<MusaitKopyaDto>>
{
    public Guid EserId { get; set; }            // veya KitapId
    public Guid? KutuphaneId { get; set; }      // opsiyonel filtre
    
    public class GetMusaitKopyalarQueryHandler 
        : IRequestHandler<GetListMusaitKopyalarQuery, List<MusaitKopyaDto>>
    {
        private readonly IKopyaRepository _kopyaRepository;
        private readonly IOduncRepository _oduncRepository;

        public GetMusaitKopyalarQueryHandler(
            IKopyaRepository kopyaRepository,
            IOduncRepository oduncRepository)
        {
            _kopyaRepository = kopyaRepository;
            _oduncRepository = oduncRepository;
        }

        public async Task<List<MusaitKopyaDto>> Handle(GetListMusaitKopyalarQuery request, CancellationToken ct)
        {
            // İlgili eserin kopyaları
            var baseQuery = _kopyaRepository.Query()
                .Where(k => k.KitapId == request.EserId);

            if (request.KutuphaneId.HasValue)
                baseQuery = baseQuery.Where(k => k.KutuphaneId == request.KutuphaneId.Value);

            // Aktif odunc/rezerv kaydı olan kopyaları dışla
            // (OduncVerildi veya RezerveEdildi)
            var result = await baseQuery
                .Where(k => !_oduncRepository.Query()
                    .Any(o => o.KopyaId == k.Id &&
                              (o.Durum == OduncDurum.OduncVerildi || o.Durum == OduncDurum.RezerveEdildi)))
                .Select(k => new MusaitKopyaDto
                {
                    KopyaId = k.Id,
                    Barkod = k.Barkod,
                    KutuphaneId = k.KutuphaneId,
                    KutuphaneAdi = k.Kutuphane.Adi
                })
                .ToListAsync(ct);

            return result;
        }
    }
}
