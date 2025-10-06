using Application.Features.Kutuphanes.Commands.Create;
using Application.Features.Kutuphanes.Commands.Delete;
using Application.Features.Kutuphanes.Commands.Update;
using Application.Features.Kutuphanes.Queries.GetById;
using Application.Features.Kutuphanes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Kutuphanes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKutuphaneCommand, Kutuphane>();
        CreateMap<Kutuphane, CreatedKutuphaneResponse>();

        CreateMap<UpdateKutuphaneCommand, Kutuphane>();
        CreateMap<Kutuphane, UpdatedKutuphaneResponse>();

        CreateMap<DeleteKutuphaneCommand, Kutuphane>();
        CreateMap<Kutuphane, DeletedKutuphaneResponse>();

        CreateMap<Kutuphane, GetByIdKutuphaneResponse>();

        CreateMap<Kutuphane, GetListKutuphaneListItemDto>()
            .ForMember(destinationMember: k => k.UstKutuphaneAdi, memberOptions: opt => opt.MapFrom(k => k.UstKutuphane.Adi));
        
        CreateMap<IPaginate<Kutuphane>, GetListResponse<GetListKutuphaneListItemDto>>();
    }
}