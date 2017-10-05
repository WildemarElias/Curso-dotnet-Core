using Microsoft.EntityFrameworkCore;
using WatchList.Models.Mappings;

namespace WatchList.Models{
    //classe de banco de dados
    public class MovieContext : DbContext{
        public DbSet<User> Users{get;set;}
        public DbSet<Movie> Movies{get;set;}

        public MovieContext(DbContextOptions<MovieContext> options)//diz claramente que vai usar o sqlite
            :base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            new UserMapping(modelBuilder.Entity<User>());
            new MovieMapping(modelBuilder.Entity<Movie>());
        }
    }

}