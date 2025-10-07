using Application.Features.Kitaplar.Commands.Delete;
using AutoMapper;
using Domain;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;


public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateKitapCommand, Kitap>();
        CreateMap<Kitap, CreatedKitapResponse>();

        CreateMap<UpdatedKitapResponse, Kitap>();
        CreateMap<Kitap, UpdatedKitapResponse>();

        CreateMap<DeleteKitapCommand, Kitap>();
        CreateMap<Kitap, DeletedKitapResponse>();

        CreateMap<Kitap, GetByIdKitapResponse>();

        CreateMap<Kitap, GetListKitapListItemDto>()
            .ForMember(dest => dest.YazarAdları,
                opt => opt.MapFrom(src =>
                    src.EserlerYazarlar.Select(ey => $"{ey.Yazar.Adi} {ey.Yazar.Soyadi}").ToList()));
        CreateMap<IPaginate<Kitap>, GetListResponse<GetListKitapListItemDto>>();
    }
}