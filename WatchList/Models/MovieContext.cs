using Microsoft.EntityFrameworkCore;

namespace WatchList.Models{
    public class MovieContext : DbContext{
        public DbSet<User> Users{get;set;}
        public DbSet<Movie> Movies{get;set;}
    }

}