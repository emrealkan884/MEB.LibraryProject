using Application.Features.Eserler.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Dynamic;

namespace Application.Features.Eserler.Queries.GetListByDynamic
{
    public class GetListByDynamicEserQuery : IRequest<GetListResponse<GetListEserListItemDto>>
    {
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public class GetListByDynamicEserQueryHandler
            : IRequestHandler<GetListByDynamicEserQuery, GetListResponse<GetListEserListItemDto>>
        {
            private readonly IEserRepository _eserRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicEserQueryHandler(IEserRepository eserRepository, IMapper mapper)
            {
                _eserRepository = eserRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListEserListItemDto>> Handle(
                GetListByDynamicEserQuery request, CancellationToken cancellationToken)
            {
                var eserler = await _eserRepository.GetListByDynamicAsync(
                    dynamic: request.DynamicQuery,
                    include: e => e
                        .Include(e => e.EserlerYazarlar)
                        .ThenInclude(ey => ey.Yazar),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken
                );

                return _mapper.Map<GetListResponse<GetListEserListItemDto>>(eserler);
            }
        }
    }
}