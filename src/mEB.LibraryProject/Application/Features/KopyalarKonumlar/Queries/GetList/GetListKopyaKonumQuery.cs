using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.KopyalarKonumlar.Queries.GetList;

public class GetListKopyaKonumQuery : IRequest<GetListResponse<GetListKopyaKonumListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListKopyaKonumQueryHandler : IRequestHandler<GetListKopyaKonumQuery, GetListResponse<GetListKopyaKonumListItemDto>>
    {
        private readonly IKopyaKonumRepository _kopyaKonumRepository;
        private readonly IMapper _mapper;

        public GetListKopyaKonumQueryHandler(IKopyaKonumRepository kopyaKonumRepository, IMapper mapper)
        {
            _kopyaKonumRepository = kopyaKonumRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListKopyaKonumListItemDto>> Handle(GetListKopyaKonumQuery request, CancellationToken cancellationToken)
        {
            IPaginate<KopyaKonum> kopyaKonums = await _kopyaKonumRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListKopyaKonumListItemDto> response = _mapper.Map<GetListResponse<GetListKopyaKonumListItemDto>>(kopyaKonums);
            return response;
        }
    }
}