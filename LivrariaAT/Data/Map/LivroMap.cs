using LivrariaAT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrariaAT.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.autor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ultimaatt).IsRequired().HasMaxLength(255);
            builder.Property(x => x.imagem).IsRequired().HasMaxLength(255);


            //builder.HasMany(x => x.capitulos).WithOne(x => x.livro).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
