using Application.Services.Repositories;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Persistence.Paging;


public class GetListKitapQuery : IRequest<GetListResponse<GetListKitapListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListKitapQueryHandler : IRequestHandler<GetListKitapQuery, GetListResponse<GetListKitapListItemDto>>
    {
        private readonly IKitapRepository _kitapRepository;
        private readonly IMapper _mapper;

        public GetListKitapQueryHandler(IKitapRepository kitapRepository, IMapper mapper)
        {
            _kitapRepository = kitapRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListKitapListItemDto>> Handle(GetListKitapQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<Kitap> kitaplar = await _kitapRepository.GetListAsync(
                include: k=> k
                    .Include(k=>k.EserlerYazarlar).ThenInclude(ey => ey.Yazar)
                    .Include(k=>k.Baskilar).ThenInclude(b => b.YayinEvi),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListKitapListItemDto> response =
                _mapper.Map<GetListResponse<GetListKitapListItemDto>>(kitaplar);
            return response;
        }
    }
}