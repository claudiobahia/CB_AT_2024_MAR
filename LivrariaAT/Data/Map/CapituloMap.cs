using LivrariaAT.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LivrariaAT.Data.Map
{
    public class CapituloMap : IEntityTypeConfiguration<Capitulo>
    {
        public void Configure(EntityTypeBuilder<Capitulo> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.titulo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(255);

             builder.Property(u => u.livroid).IsRequired();
           // builder.HasOne(c => c.livro).HasForeignKey(c => c.livroid).IsRequired().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
