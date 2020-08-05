using MusicStore.Core.Utilities;
using System;

namespace MusicStore.Core.Entities
{
	public class Song : Entity
	{
		private Song()
		{
			DateAdded = DateTime.Now;
		}
		public Song(string title, string artist, Genre genre)
			: this()
		{
			Title = title;
			Artist = artist;
			Genre = genre;
		}

		public string Title { get; set; }
		public string Artist { get; set; }
		public Genre Genre { get; set; }
		public DateTime DateAdded { get; private set; }
	}
}
