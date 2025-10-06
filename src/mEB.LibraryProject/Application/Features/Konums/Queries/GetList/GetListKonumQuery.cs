using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Konums.Queries.GetList;

public class GetListKonumQuery : IRequest<GetListResponse<GetListKonumListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListKonumQueryHandler : IRequestHandler<GetListKonumQuery, GetListResponse<GetListKonumListItemDto>>
    {
        private readonly IKonumRepository _konumRepository;
        private readonly IMapper _mapper;

        public GetListKonumQueryHandler(IKonumRepository konumRepository, IMapper mapper)
        {
            _konumRepository = konumRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListKonumListItemDto>> Handle(GetListKonumQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Konum> konums = await _konumRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListKonumListItemDto> response = _mapper.Map<GetListResponse<GetListKonumListItemDto>>(konums);
            return response;
        }
    }
}