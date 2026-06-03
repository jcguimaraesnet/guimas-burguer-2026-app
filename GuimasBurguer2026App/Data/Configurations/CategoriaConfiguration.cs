using GuimasBurguer2026App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuimasBurguer2026App.Data.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasData(
            new Categoria { CategoriaId = 1, Descricao = "Calórico" },
            new Categoria { CategoriaId = 2, Descricao = "Vegano" },
            new Categoria { CategoriaId = 3, Descricao = "Light" }
        );
    }
}
