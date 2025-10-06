using Application.Features.KopyaKonums.Commands.Create;
using Application.Features.KopyaKonums.Commands.Delete;
using Application.Features.KopyaKonums.Commands.Update;
using Application.Features.KopyaKonums.Queries.GetById;
using Application.Features.KopyaKonums.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.KopyaKonums.Profiles;

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