using Application.Features.Konumlar.Commands.Create;
using Application.Features.Konumlar.Commands.Delete;
using Application.Features.Konumlar.Commands.Update;
using Application.Features.Konumlar.Queries.GetById;
using Application.Features.Konumlar.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Konumlar.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKonumCommand, Konum>();
        CreateMap<Konum, CreatedKonumResponse>();

        CreateMap<UpdateKonumCommand, Konum>();
        CreateMap<Konum, UpdatedKonumResponse>();

        CreateMap<DeleteKonumCommand, Konum>();
        CreateMap<Konum, DeletedKonumResponse>();

        CreateMap<Konum, GetByIdKonumResponse>();

        CreateMap<Konum, GetListKonumListItemDto>();
        CreateMap<IPaginate<Konum>, GetListResponse<GetListKonumListItemDto>>();
    }
}