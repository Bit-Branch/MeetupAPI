using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MeetupAPI.Domain.Entities;

namespace MeetupAPI.Infrastructure.Configurations
{
    public class MeetupConfiguration : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> typeBuilder)
        {
            typeBuilder.HasKey(m => m.Id);

            typeBuilder.Property(m => m.Name).HasColumnName("Name").HasColumnType("nvarchar(255)").IsRequired();
            
            typeBuilder.Property(m => m.Description).HasColumnName("Description").HasColumnType("nvarchar(1000)").IsRequired();
            
            typeBuilder.Property(m => m.Plan).HasColumnName("Plan").HasColumnType("nvarchar(1000)").IsRequired();
            
            typeBuilder.Property(m => m.Creator).HasColumnName("Creator").HasColumnType("nvarchar(100)").IsRequired();
            
            typeBuilder.Property(m => m.Speaker).HasColumnName("Speaker").HasColumnType("nvarchar(100)").IsRequired();
            
            typeBuilder.Property(m => m.MeetupTime).HasColumnName("MeetupTime").HasColumnType("datetimeoffset").IsRequired();
            
            typeBuilder.Property(m => m.MeetupPlace).HasColumnName("MeetupPlace").HasColumnType("nvarchar(255)").IsRequired();
        }
    }
}
