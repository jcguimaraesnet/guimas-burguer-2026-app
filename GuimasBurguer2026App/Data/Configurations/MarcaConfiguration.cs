using GuimasBurguer2026App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuimasBurguer2026App.Data.Configurations;

public class MarcaConfiguration : IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder)
    {
        builder.Property(m => m.Nome)
            .HasColumnName(nameof(Marca.Nome));

        builder.HasData(
            new Marca { MarcaId = 1, Nome = "Sadia" },
            new Marca { MarcaId = 2, Nome = "Seara" }
        );
    }
}
