using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WatchList.Models.Mappings{
    public class UserMapping{
        public UserMapping(EntityTypeBuilder<User> builder){
            builder
                .ToTable("User");
            builder
                .HasKey(user => user.Id);
            builder
                .Property(user => user.Id)
                .ValueGeneratedOnAdd();
            builder
                .Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder
                .HasMany(user => user.Movies)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId);

        }
    }



}