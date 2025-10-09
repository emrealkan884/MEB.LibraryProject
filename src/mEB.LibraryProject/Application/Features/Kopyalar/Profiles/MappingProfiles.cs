using Application.Features.Kopyalar.Commands.Create;
using Application.Features.Kopyalar.Commands.Delete;
using Application.Features.Kopyalar.Commands.Update;
using Application.Features.Kopyalar.Queries.GetById;
using Application.Features.Kopyalar.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Kopyalar.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKopyaCommand, Kopya>();
        CreateMap<Kopya, CreatedKopyaResponse>();
        CreateMap<Kitap, KitapInKopyaDto>()
            .ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => src.Kategori))
            .ForMember(dest => dest.YazarAdları,
                opt => opt.MapFrom(src =>
                    src.EserlerYazarlar.Select(ey => $"{ey.Yazar.Adi} {ey.Yazar.Soyadi}").ToList()));

        // When projecting a Kopya, populate edition info from KitapBaski
        CreateMap<KitapBaski, KitapInKopyaDto>()
            .ForMember(dest => dest.BaskiISBN, opt => opt.MapFrom(src => src.Isbn))
            .ForMember(dest => dest.BaskiBilgisi, opt => opt.MapFrom(src => src.BaskiBilgisi))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Adi, opt => opt.MapFrom(src => src.Kitap.Adi))
            .ForMember(dest => dest.DilKodu, opt => opt.MapFrom(src => src.Kitap.DilKodu))
            .ForMember(dest => dest.Aciklama, opt => opt.MapFrom(src => src.Kitap.Aciklama))
            .ForMember(dest => dest.DeweyKodu, opt => opt.MapFrom(src => src.Kitap.DeweyKodu))
            .ForMember(dest => dest.MarcVerisi, opt => opt.MapFrom(src => src.Kitap.MarcVerisi))
            .ForMember(dest => dest.Kategori, opt => opt.MapFrom(src => src.Kitap.Kategori))
            .ForMember(dest => dest.YazarAdları,
                opt => opt.MapFrom(src => src.Kitap.EserlerYazarlar.Select(ey => $"{ey.Yazar.Adi} {ey.Yazar.Soyadi}").ToList()));

        CreateMap<UpdateKopyaCommand, Kopya>();
        CreateMap<Kopya, UpdatedKopyaResponse>();

        CreateMap<DeleteKopyaCommand, Kopya>();
        CreateMap<Kopya, DeletedKopyaResponse>();

        CreateMap<Kopya, GetByIdKopyaResponse>();

        CreateMap<Kopya, GetListKopyaListItemDto>().ReverseMap();
        CreateMap<IPaginate<Kopya>, GetListResponse<GetListKopyaListItemDto>>();
    }
}