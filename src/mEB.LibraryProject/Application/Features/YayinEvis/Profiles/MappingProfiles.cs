using Application.Features.YayinEvis.Commands.Create;
using Application.Features.YayinEvis.Commands.Delete;
using Application.Features.YayinEvis.Commands.Update;
using Application.Features.YayinEvis.Queries.GetById;
using Application.Features.YayinEvis.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.YayinEvis.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateYayinEviCommand, YayinEvi>();
        CreateMap<YayinEvi, CreatedYayinEviResponse>();

        CreateMap<UpdateYayinEviCommand, YayinEvi>();
        CreateMap<YayinEvi, UpdatedYayinEviResponse>();

        CreateMap<DeleteYayinEviCommand, YayinEvi>();
        CreateMap<YayinEvi, DeletedYayinEviResponse>();

        CreateMap<YayinEvi, GetByIdYayinEviResponse>();

        CreateMap<YayinEvi, GetListYayinEviListItemDto>();
        CreateMap<IPaginate<YayinEvi>, GetListResponse<GetListYayinEviListItemDto>>();
    }
}