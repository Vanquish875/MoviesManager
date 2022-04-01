using MoviesManager.Models;

namespace MoviesManager.DataManager
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
