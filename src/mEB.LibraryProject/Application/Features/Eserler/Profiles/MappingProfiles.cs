using Application.Features.Eserler.Commands.Create;
using Application.Features.Eserler.Commands.Delete;
using Application.Features.Eserler.Commands.Update;
using Application.Features.Eserler.Queries.GetById;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Eserler.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateEserCommand, Eser>();
        CreateMap<Eser, CreatedEserResponse>();

        CreateMap<UpdateEserCommand, Eser>();
        CreateMap<Eser, UpdatedEserResponse>();

        CreateMap<DeleteEserCommand, Eser>();
        CreateMap<Eser, DeletedEserResponse>();

        CreateMap<Eser, GetByIdEserResponse>();

        CreateMap<Eser, GetListKitapListItemDto>();
        CreateMap<IPaginate<Eser>, GetListResponse<GetListKitapListItemDto>>();
    }
}