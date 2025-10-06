using Application.Features.EserYazars.Commands.Create;
using Application.Features.EserYazars.Commands.Delete;
using Application.Features.EserYazars.Commands.Update;
using Application.Features.EserYazars.Queries.GetById;
using Application.Features.EserYazars.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.EserYazars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateEserYazarCommand, EserYazar>();
        CreateMap<EserYazar, CreatedEserYazarResponse>()
            .ForMember(destinationMember: c => c.EserAdi, memberOptions: opt=> opt.MapFrom(c => c.Eser.Adi))
            .ForMember(destinationMember: c => c.YazarAdi, memberOptions: opt => opt.MapFrom(c => c.Yazar.Adi))
            .ForMember(destinationMember: c => c.YazarSoyadi, memberOptions: opt => opt.MapFrom(c => c.Yazar.Soyadi))
            .ReverseMap();

        CreateMap<UpdateEserYazarCommand, EserYazar>();
        CreateMap<EserYazar, UpdatedEserYazarResponse>();

        CreateMap<DeleteEserYazarCommand, EserYazar>();
        CreateMap<EserYazar, DeletedEserYazarResponse>();

        CreateMap<EserYazar, GetByIdEserYazarResponse>();

        CreateMap<EserYazar, GetListEserYazarListItemDto>()
            .ForMember(destinationMember: c => c.EserAdi, memberOptions: opt=> opt.MapFrom(c => c.Eser.Adi))
            .ForMember(destinationMember: c => c.YazarAdi, memberOptions: opt => opt.MapFrom(c => c.Yazar.Adi))
            .ForMember(destinationMember: c => c.YazarSoyadi, memberOptions: opt => opt.MapFrom(c => c.Yazar.Soyadi))
            .ReverseMap();
        CreateMap<IPaginate<EserYazar>, GetListResponse<GetListEserYazarListItemDto>>();
    }
}