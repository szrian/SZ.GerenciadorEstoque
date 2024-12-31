using SZ.GerenciadorEstoque.Aplicacao.ViewModels;
using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Aplicacao.Conversores;

public interface IProdutoConversor
{
    Produto ConverterParaEntidadeAdicionar(ProdutoViewModel produtoViewModel);
    Produto ConverterParaEntidadeAtualizar(ProdutoViewModel produtoViewModel);
    ProdutoViewModel ConverterParaViewModel(Produto produto);
}
public class ProdutoConversor : IProdutoConversor
{
    public Produto ConverterParaEntidadeAdicionar(ProdutoViewModel produtoViewModel)
        => new(produtoViewModel.Nome,
            produtoViewModel.Descricao,
            produtoViewModel.PrecoCusto,
            produtoViewModel.Status);

    public Produto ConverterParaEntidadeAtualizar(ProdutoViewModel produtoViewModel)
        => new(produtoViewModel.Id,
            produtoViewModel.Nome,
            produtoViewModel.Descricao,
            produtoViewModel.PrecoCusto,
            produtoViewModel.PrecoVenda,
            produtoViewModel.DataVenda,
            produtoViewModel.Status,
            produtoViewModel.Excluido);

    public ProdutoViewModel ConverterParaViewModel(Produto produto)
    {
        return new ProdutoViewModel
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            PrecoCusto = produto.PrecoCusto,
            PrecoVenda = produto.PrecoVenda,
            DataVenda = produto.DataVenda,
            Status = produto.Status,
            Excluido = produto.Excluido
        };
    }
}
