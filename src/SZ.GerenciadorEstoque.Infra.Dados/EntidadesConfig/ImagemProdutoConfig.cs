using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Infra.Dados.EntidadesConfig;

public class ImagemProdutoConfig : IEntityTypeConfiguration<ImagemProduto>
{
    private const string NomeTabela = "ImagensProdutos";
    public void Configure(EntityTypeBuilder<ImagemProduto> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(P => P.Id)
            .HasColumnOrder(1);

        builder.Property(P => P.NomeImagem)
            .HasMaxLength(200)
            .HasColumnOrder(2)
            .IsRequired();

        builder.Property(P => P.CaminhoArquivo)
            .HasColumnType("varchar(2000)")
            .HasColumnOrder(3);

        builder.Property(P => P.ProdutoId)
            .HasColumnOrder(4);

        builder.Property(P => P.Excluido)
            .IsRequired()
            .HasColumnOrder(5);

        builder.HasOne(p => p.Produto)
            .WithMany(q => q.ImagensProduto)
            .HasForeignKey(r => r.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(NomeTabela);
    }
}
