using Application.Features.KopyaBirimler.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.KopyaBirimler.Profiles;

public class KopyaBirimMappingProfiles : Profile
{
	public KopyaBirimMappingProfiles()
	{
		CreateMap<KopyaBirim, KopyaBirimDto>()
			.ForMember(d => d.Durum, m => m.MapFrom(s => s.Durum.ToString()));
	}
}


