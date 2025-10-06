using Application.Features.Esers.Commands.Create;
using Application.Features.Esers.Commands.Delete;
using Application.Features.Esers.Commands.Update;
using Application.Features.Esers.Queries.GetById;
using Application.Features.Esers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Esers.Profiles;

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

        CreateMap<Eser, GetListEserListItemDto>();
        CreateMap<IPaginate<Eser>, GetListResponse<GetListEserListItemDto>>();
    }
}