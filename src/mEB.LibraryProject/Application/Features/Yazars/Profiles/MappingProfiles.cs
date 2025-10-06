using Application.Features.Yazars.Commands.Create;
using Application.Features.Yazars.Commands.Delete;
using Application.Features.Yazars.Commands.Update;
using Application.Features.Yazars.Queries.GetById;
using Application.Features.Yazars.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Yazars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateYazarCommand, Yazar>();
        CreateMap<Yazar, CreatedYazarResponse>();

        CreateMap<UpdateYazarCommand, Yazar>();
        CreateMap<Yazar, UpdatedYazarResponse>();

        CreateMap<DeleteYazarCommand, Yazar>();
        CreateMap<Yazar, DeletedYazarResponse>();

        CreateMap<Yazar, GetByIdYazarResponse>();

        CreateMap<Yazar, GetListYazarListItemDto>();
        CreateMap<IPaginate<Yazar>, GetListResponse<GetListYazarListItemDto>>();
    }
}