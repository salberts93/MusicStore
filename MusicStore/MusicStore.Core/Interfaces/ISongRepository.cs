using MusicStore.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStore.Core.Interfaces
{
	public interface ISongRepository
	{
		Task<IEnumerable<Song>> GetAll();
		Task<Song> GetById(int id);
		Task Save(Song song);
		Task Delete(Song song);
	}
}
