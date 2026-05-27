using GuimasBurguer2026App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuimasBurguer2026App.Data.Configurations;

public class HamburguerConfiguration : IEntityTypeConfiguration<Hamburguer>
{
    public void Configure(EntityTypeBuilder<Hamburguer> builder)
    {
        builder.Property(h => h.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(100);

        builder.Property(h => h.EntregaExpressa)
            .HasColumnName(nameof(Hamburguer.EntregaExpressa))
            .HasConversion<int>();

        builder.Property(h => h.DataCadastro)
            .HasColumnName(nameof(Hamburguer.DataCadastro));

        builder.HasQueryFilter(h => h.DataCadastro <= DateTime.Now);
    }
}
