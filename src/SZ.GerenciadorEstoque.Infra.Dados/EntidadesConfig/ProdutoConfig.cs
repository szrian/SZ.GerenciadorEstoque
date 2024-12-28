using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Infra.Dados.EntidadesConfig;

public class ProdutoConfig : IEntityTypeConfiguration<Produto>
{
    private const string NomeTabela = "Produtos";

    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(P => P.Id)
            .HasColumnOrder(1);

        builder.Property(P => P.Nome)
            .HasMaxLength(150)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(P => P.Descricao)
            .HasMaxLength(400)
            .HasColumnOrder(3);

        builder.Property(P => P.PrecoCusto)
            .HasColumnType("decimal(10,2)")
            .HasColumnOrder(4)
            .IsRequired();

        builder.Property(P => P.PrecoVenda)
            .HasColumnType("decimal(10,2)")
            .HasColumnOrder(5);

        builder.Property(P => P.Status)
            .IsRequired()
            .HasColumnOrder(6);

        builder.Property(P => P.Excluido)
            .IsRequired()
            .HasColumnOrder(7);

        builder.ToTable(NomeTabela);
    }
}
