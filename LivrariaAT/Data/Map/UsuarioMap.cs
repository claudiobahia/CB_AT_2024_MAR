using LivrariaAT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaAT.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.status).IsRequired();
            builder.Property(x => x.permissao).IsRequired();

            builder.Property(u => u.favoritos)
                  .HasConversion(v => string.Join(',', v),v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

        }
    }
}
