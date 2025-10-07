using Application.Features.KopyalarKonumlar.Commands.Create;
using Application.Features.KopyalarKonumlar.Commands.Delete;
using Application.Features.KopyalarKonumlar.Commands.Update;
using Application.Features.KopyalarKonumlar.Queries.GetById;
using Application.Features.KopyalarKonumlar.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.KopyalarKonumlar.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKopyaKonumCommand, KopyaKonum>();
        CreateMap<KopyaKonum, CreatedKopyaKonumResponse>();

        CreateMap<UpdateKopyaKonumCommand, KopyaKonum>();
        CreateMap<KopyaKonum, UpdatedKopyaKonumResponse>();

        CreateMap<DeleteKopyaKonumCommand, KopyaKonum>();
        CreateMap<KopyaKonum, DeletedKopyaKonumResponse>();

        CreateMap<KopyaKonum, GetByIdKopyaKonumResponse>();

        CreateMap<KopyaKonum, GetListKopyaKonumListItemDto>();
        CreateMap<IPaginate<KopyaKonum>, GetListResponse<GetListKopyaKonumListItemDto>>();
    }
}