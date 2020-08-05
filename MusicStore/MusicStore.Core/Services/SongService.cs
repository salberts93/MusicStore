using AutoMapper;
using MusicStore.Core.DTOs;
using MusicStore.Core.Entities;
using MusicStore.Core.Interfaces;
using MusicStore.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Core.Services
{
	public class SongService : ISongService
	{
		private readonly ISongRepository songRepository;
		private readonly IMapper mapper;
		public SongService(ISongRepository songRepository, IMapper mapper)
		{
			this.songRepository = songRepository;
			this.mapper = mapper;
		}

		public async Task<OperationResult<IEnumerable<SongDTO>>> GetAll()
		{
			var songs = await songRepository.GetAll();
			return OperationResult<IEnumerable<SongDTO>>.CreateSuccessResult(mapper.Map<IEnumerable<SongDTO>>(songs));
		}

		public async Task<OperationResult<IEnumerable<SongDTO>>> GetByArtist(string searchTerm)
		{
			var songs = await songRepository.GetAll();
			var filteredSongs = songs.Where(song => song.Artist.ToLower().Contains(searchTerm.ToLower()));
			if (!filteredSongs.Any())
			{
				return OperationResult<IEnumerable<SongDTO>>.CreateNonSuccessResult("No songs matching the search criterium were found");
			}
			return OperationResult<IEnumerable<SongDTO>>.CreateSuccessResult(mapper.Map<IEnumerable<SongDTO>>(filteredSongs));
		}

		public async Task<OperationResult<SongDTO>> Save(SongDTO songDTO)
		{
			var song = mapper.Map<Song>(songDTO);
			// Validation for songs could be added here, return a non-success if something was wrong
			await songRepository.Save(song);
			return OperationResult<SongDTO>.CreateSuccessResult(mapper.Map<SongDTO>(song));
		}

		public async Task<OperationResult<SongDTO>> Delete(int id)
		{
			var song = await songRepository.GetById(id);
			if (song == null)
			{
				return OperationResult<SongDTO>.CreateNonSuccessResult("No song with the given id was found");
			}
			await songRepository.Delete(song);
			return OperationResult<SongDTO>.CreateSuccessResult();

		}
	}
}
