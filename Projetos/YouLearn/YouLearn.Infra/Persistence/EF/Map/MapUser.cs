using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YouLearn.Domain.Entities;
using YouLearn.Domain.ObjectValue;

namespace YouLearn.Infra.Persistence.EF.Map
{
    public class MapUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Name da Tabela
            builder.ToTable("User");

            //Chave primaria
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Password).HasMaxLength(36).IsRequired();

            //Mapeando objetos de valor
            builder.OwnsOne<Name>(x => x.Name, cb => {
                cb.Property(x => x.FirstName).HasMaxLength(50).HasColumnName("FirstName").IsRequired();
                cb.Property(x => x.LastName).HasMaxLength(50).HasColumnName("LastName").IsRequired();
            });

            builder.OwnsOne<Email>(x => x.Email, cb => {
                cb.Property(x => x.Address).HasMaxLength(200).HasColumnName("Email").IsRequired();
            });

        }
    }
}
