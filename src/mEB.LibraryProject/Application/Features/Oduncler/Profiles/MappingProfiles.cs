using Application.Features.Oduncler.Commands.Create;
using Application.Features.Oduncler.Commands.Delete;
using Application.Features.Oduncler.Commands.TeslimEt;
using Application.Features.Oduncler.Commands.Update;
using Application.Features.Oduncler.Queries.GetById;
using Application.Features.Oduncler.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Oduncler.Profiles;

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