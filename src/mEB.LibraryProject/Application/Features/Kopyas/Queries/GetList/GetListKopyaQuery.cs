using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Kopyas.Queries.GetList;

public class GetListKopyaQuery : IRequest<GetListResponse<GetListKopyaListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListKopyaQueryHandler : IRequestHandler<GetListKopyaQuery, GetListResponse<GetListKopyaListItemDto>>
    {
        private readonly IKopyaRepository _kopyaRepository;
        private readonly IMapper _mapper;

        public GetListKopyaQueryHandler(IKopyaRepository kopyaRepository, IMapper mapper)
        {
            _kopyaRepository = kopyaRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListKopyaListItemDto>> Handle(GetListKopyaQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Kopya> kopyas = await _kopyaRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListKopyaListItemDto> response = _mapper.Map<GetListResponse<GetListKopyaListItemDto>>(kopyas);
            return response;
        }
    }
}