using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapPlayList : IEntityTypeConfiguration<PlayList>
    {
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {

            builder.ToTable("PlayList");
            //Foreikey
            builder.HasOne(x => x.User).WithMany().HasForeignKey("IdUser");

            //Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}
