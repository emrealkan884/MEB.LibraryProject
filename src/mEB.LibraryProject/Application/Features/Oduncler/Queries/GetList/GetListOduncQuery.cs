using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Oduncler.Queries.GetList;

public class GetListOduncQuery : IRequest<GetListResponse<GetListOduncListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOduncQueryHandler : IRequestHandler<GetListOduncQuery, GetListResponse<GetListOduncListItemDto>>
    {
        private readonly IOduncRepository _oduncRepository;
        private readonly IMapper _mapper;

        public GetListOduncQueryHandler(IOduncRepository oduncRepository, IMapper mapper)
        {
            _oduncRepository = oduncRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOduncListItemDto>> Handle(GetListOduncQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Odunc> oduncs = await _oduncRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOduncListItemDto> response = _mapper.Map<GetListResponse<GetListOduncListItemDto>>(oduncs);
            return response;
        }
    }
}