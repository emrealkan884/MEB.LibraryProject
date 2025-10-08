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

        CreateMap<UpdateKopyaCommand, Kopya>();
        CreateMap<Kopya, UpdatedKopyaResponse>();

        CreateMap<DeleteKopyaCommand, Kopya>();
        CreateMap<Kopya, DeletedKopyaResponse>();

        CreateMap<Kopya, GetByIdKopyaResponse>();

        CreateMap<Kopya, GetListKopyaListItemDto>().ReverseMap();
        CreateMap<IPaginate<Kopya>, GetListResponse<GetListKopyaListItemDto>>();
    }
}