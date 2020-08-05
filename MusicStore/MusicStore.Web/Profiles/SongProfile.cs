using AutoMapper;
using MusicStore.Core.DTOs;
using MusicStore.Core.Entities;

namespace MusicStore.Web.Profiles
{
	public class SongProfile : Profile
	{
		public SongProfile()
		{
			CreateMap<Song, SongDTO>().ReverseMap();
		}
	}
}
