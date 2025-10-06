using Application.Features.Konums.Commands.Create;
using Application.Features.Konums.Commands.Delete;
using Application.Features.Konums.Commands.Update;
using Application.Features.Konums.Queries.GetById;
using Application.Features.Konums.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Konums.Profiles;

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