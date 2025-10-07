using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Eserler.Queries.GetList;

public class GetListEserQuery : IRequest<GetListResponse<GetListEserListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListEserQueryHandler : IRequestHandler<GetListEserQuery, GetListResponse<GetListEserListItemDto>>
    {
        private readonly IEserRepository _eserRepository;
        private readonly IMapper _mapper;

        public GetListEserQueryHandler(IEserRepository eserRepository, IMapper mapper)
        {
            _eserRepository = eserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEserListItemDto>> Handle(GetListEserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Eser> esers = await _eserRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEserListItemDto> response = _mapper.Map<GetListResponse<GetListEserListItemDto>>(esers);
            return response;
        }
    }
}