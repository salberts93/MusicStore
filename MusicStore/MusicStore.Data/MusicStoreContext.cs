using Microsoft.EntityFrameworkCore;
using MusicStore.Core.Entities;

namespace MusicStore.Data
{
	public class MusicStoreContext : DbContext
	{
		public MusicStoreContext(DbContextOptions<MusicStoreContext> options) : base(options) { }

		public DbSet<Song> Songs { get; set; }
	}
}
