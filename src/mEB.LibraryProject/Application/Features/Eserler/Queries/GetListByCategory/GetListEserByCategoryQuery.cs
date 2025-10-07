using Application.Features.Eserler.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Eserler.Queries.GetListByCategory;

public class GetListEserByKategoriQuery : IRequest<GetListResponse<GetListEserListItemDto>>
{
    public EserKategorisi Kategori { get; set; }

    public class GetListEserByKategoriQueryHandler
        : IRequestHandler<GetListEserByKategoriQuery, GetListResponse<GetListEserListItemDto>>
    {
        private readonly IEserRepository _eserRepository;
        private readonly IMapper _mapper;

        public GetListEserByKategoriQueryHandler(IEserRepository eserRepository, IMapper mapper)
        {
            _eserRepository = eserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEserListItemDto>> Handle(
            GetListEserByKategoriQuery request,
            CancellationToken cancellationToken)
        {
            var eserler = await _eserRepository.GetListAsync(
                predicate: e => e.Kategori == request.Kategori,
                include: e => e
                    .Include(x => x.EserlerYazarlar)
                    .ThenInclude(ey => ey.Yazar),
                cancellationToken: cancellationToken
            );

            return _mapper.Map<GetListResponse<GetListEserListItemDto>>(eserler);
        }
    }
}