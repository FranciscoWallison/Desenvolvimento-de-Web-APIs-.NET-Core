using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entities;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapChannel : IEntityTypeConfiguration<Channel>
    {
        public void Configure(EntityTypeBuilder<Channel> builder)
        {

            builder.ToTable("Channel");
            //Foreikey
            builder.HasOne(x => x.User).WithMany().HasForeignKey("IdUser");
            
            //Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.UrlLogo).HasMaxLength(255).IsRequired();

        }
    }
}
