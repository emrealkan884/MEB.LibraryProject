using Application.Features.Eserler.Commands.Create;
using Application.Features.Eserler.Commands.Delete;
using Application.Features.Eserler.Commands.Update;
using Application.Features.Eserler.Queries.GetById;
using Application.Features.Eserler.Queries.GetList;
using Application.Features.Eserler.Queries.GetListByDynamic;
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

        CreateMap<Eser, GetListEserListItemDto>()
            .ForMember(dest => dest.Kategori,
                opt => opt.MapFrom(src => src.Kategori.ToString()))
            .ForMember(dest => dest.EserTipi,
                opt => opt.MapFrom(src => src.EserTipi.ToString()))
            .ForMember(dest => dest.YazarAdlari,
                opt => opt.MapFrom(src =>
                    src.Yazarlar.Select(ey => $"{ey.Yazar.Adi} {ey.Yazar.Soyadi}").ToList()));

        CreateMap<Eser, GetListByDynamicEserListItemDto>()
            .ForMember(dest => dest.YazarAdları,
                opt => opt.MapFrom(src =>
                    src.Yazarlar
                        .Select(ey => $"{ey.Yazar.Adi} {ey.Yazar.Soyadi}")
                        .ToList()))
            .ForMember(dest => dest.EserTipi,
                opt => opt.MapFrom(src => src.EserTipi.ToString()))
            .ForMember(dest => dest.Kategori,
                opt => opt.MapFrom(src => src.Kategori.ToString()));
        
        CreateMap<IPaginate<Eser>, GetListResponse<GetListEserListItemDto>>();
        CreateMap<IPaginate<Eser>, GetListResponse<GetListByDynamicEserListItemDto>>();
    }
}