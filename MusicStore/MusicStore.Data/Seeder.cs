using Microsoft.EntityFrameworkCore.Internal;
using MusicStore.Core.Entities;
using MusicStore.Core.Interfaces;

namespace MusicStore.Data
{
	public class Seeder : ISeeder
	{
		private readonly MusicStoreContext context;

		public Seeder(MusicStoreContext context)
		{
			this.context = context;
		}

		public void Seed()
		{
			context.Database.EnsureCreated();
			if (!HasBeenSeeded())
			{
				var songs = new Song[]
				{
					new Song("Sk8erboi", "Avril Lavigne", Core.Utilities.Genre.Pop),
					new Song("Ebla", "E.S. Posthumus", Core.Utilities.Genre.Classic),
					new Song("Country Roads, Take Me Home", "John Denver", Core.Utilities.Genre.Country)
				};
				context.Songs.AddRange(songs);
				context.SaveChanges();
			}
		}

		private bool HasBeenSeeded() => context.Songs.Any();
	}
}
