using Application.Features.Oduncs.Commands.Create;
using Application.Features.Oduncs.Commands.Delete;
using Application.Features.Oduncs.Commands.TeslimEt;
using Application.Features.Oduncs.Commands.Update;
using Application.Features.Oduncs.Queries.GetById;
using Application.Features.Oduncs.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Oduncs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateOduncCommand, Odunc>();
        CreateMap<Odunc, CreatedOduncResponse>();

        CreateMap<UpdateOduncCommand, Odunc>();
        CreateMap<Odunc, UpdatedOduncResponse>();

        CreateMap<DeleteOduncCommand, Odunc>();
        CreateMap<Odunc, DeletedOduncResponse>();

        CreateMap<Odunc, GetByIdOduncResponse>();

        CreateMap<Odunc, GetListOduncListItemDto>();
        CreateMap<IPaginate<Odunc>, GetListResponse<GetListOduncListItemDto>>();
        
        CreateMap<Odunc, TeslimEdildiOduncResponse>();

    }
}