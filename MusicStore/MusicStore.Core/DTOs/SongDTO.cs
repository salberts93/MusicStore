using System;

namespace MusicStore.Core.DTOs
{
	public class SongDTO
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Artist { get; set; }
		public string Genre { get; set; }
		public DateTime DateAdded { get; set; }
	}
}
