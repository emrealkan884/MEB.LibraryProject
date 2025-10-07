using Application.Features.Kitaplar.Commands.Delete;
using AutoMapper;
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

        CreateMap<Kitap, GetListKitapListItemDto>();
        CreateMap<IPaginate<Kitap>, GetListResponse<GetListKitapListItemDto>>();
    }
}