using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MeetupAPI.Domain.Entities;

namespace MeetupAPI.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> typeBuilder)
        {
            typeBuilder.HasKey(u => u.Id);
            
            typeBuilder.Property(u => u.Login).HasColumnName("Login").HasColumnType("nvarchar(255)").IsRequired();
            
            typeBuilder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").HasColumnType("char(60)").IsRequired();
        }
    }
}
