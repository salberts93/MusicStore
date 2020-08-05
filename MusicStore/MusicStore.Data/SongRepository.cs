using Microsoft.EntityFrameworkCore;
using MusicStore.Core.Entities;
using MusicStore.Core.Interfaces;
using MusicStore.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Data
{
	public class SongRepository : ISongRepository
	{
		private readonly MusicStoreContext musicStoreContext;

		public SongRepository(MusicStoreContext musicStoreContext)
		{
			this.musicStoreContext = musicStoreContext;
		}

		public async Task<IEnumerable<Song>> GetAll()
		{
			return await musicStoreContext.Songs.ToListAsync();		
		}

		public async Task<Song> GetById(int id)
		{
			return await musicStoreContext.Songs.FindAsync(id);
		}

		public async Task Save(Song song)
		{
			musicStoreContext.Add(song);
			await musicStoreContext.SaveChangesAsync();
		}

		public async Task Delete(Song song)
		{
			musicStoreContext.Remove(song);
			await musicStoreContext.SaveChangesAsync();
		}
	}
}
