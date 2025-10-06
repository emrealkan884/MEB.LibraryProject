using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.EserYazars.Queries.GetList;

public class GetListEserYazarQuery : IRequest<GetListResponse<GetListEserYazarListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListEserYazarQueryHandler : IRequestHandler<GetListEserYazarQuery, GetListResponse<GetListEserYazarListItemDto>>
    {
        private readonly IEserYazarRepository _eserYazarRepository;
        private readonly IMapper _mapper;

        public GetListEserYazarQueryHandler(IEserYazarRepository eserYazarRepository, IMapper mapper)
        {
            _eserYazarRepository = eserYazarRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEserYazarListItemDto>> Handle(GetListEserYazarQuery request, CancellationToken cancellationToken)
        {
            IPaginate<EserYazar> eserYazars = await _eserYazarRepository.GetListAsync(
                include: ey => ey.Include(ey => ey.Eser).Include(ey => ey.Yazar),//join
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEserYazarListItemDto> response = _mapper.Map<GetListResponse<GetListEserYazarListItemDto>>(eserYazars);
            return response;
        }
    }
}