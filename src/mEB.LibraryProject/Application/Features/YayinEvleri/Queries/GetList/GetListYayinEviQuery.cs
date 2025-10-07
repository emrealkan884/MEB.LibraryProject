using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.YayinEvleri.Queries.GetList;

public class GetListYayinEviQuery : IRequest<GetListResponse<GetListYayinEviListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListYayinEviQueryHandler : IRequestHandler<GetListYayinEviQuery, GetListResponse<GetListYayinEviListItemDto>>
    {
        private readonly IYayinEviRepository _yayinEviRepository;
        private readonly IMapper _mapper;

        public GetListYayinEviQueryHandler(IYayinEviRepository yayinEviRepository, IMapper mapper)
        {
            _yayinEviRepository = yayinEviRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListYayinEviListItemDto>> Handle(GetListYayinEviQuery request, CancellationToken cancellationToken)
        {
            IPaginate<YayinEvi> yayinEvis = await _yayinEviRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListYayinEviListItemDto> response = _mapper.Map<GetListResponse<GetListYayinEviListItemDto>>(yayinEvis);
            return response;
        }
    }
}