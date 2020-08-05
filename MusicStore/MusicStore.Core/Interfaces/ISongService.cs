using MusicStore.Core.DTOs;
using MusicStore.Core.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicStore.Core.Interfaces
{
	public interface ISongService
	{
		Task<OperationResult<IEnumerable<SongDTO>>> GetAll();
		Task<OperationResult<IEnumerable<SongDTO>>> GetByArtist(string searchTerm);
		Task<OperationResult<SongDTO>> Save(SongDTO songDTO);
		Task<OperationResult<SongDTO>> Delete(int id);
	}
}
