using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WatchList.Models.Mappings{

    public class MovieMapping{
        public MovieMapping(EntityTypeBuilder<Movie> builder){
            builder
                .ToTable("Movie");
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(250);
            builder
                .Property(m => m.Watched)
                .IsRequired();
            builder
                .Property(m => m.Image)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(m => m.Grade)
                .IsRequired();
            builder.HasOne(m => m.User).WithMany(u => u.Movies).HasForeignKey(m => m.UserId);

        }
    }
}