using Application.Features.YayinEvleri.Commands.Create;
using Application.Features.YayinEvleri.Commands.Delete;
using Application.Features.YayinEvleri.Commands.Update;
using Application.Features.YayinEvleri.Queries.GetById;
using Application.Features.YayinEvleri.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.YayinEvleri.Profiles;

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