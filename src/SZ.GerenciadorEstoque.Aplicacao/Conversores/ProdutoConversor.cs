﻿using SZ.GerenciadorEstoque.Aplicacao.ViewModels;
using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Aplicacao.Conversores;

public interface IProdutoConversor
{
    Produto ConverterParaEntidadeAdicionar(ProdutoViewModel produtoViewModel);
    Produto ConverterParaEntidadeAtualizar(ProdutoViewModel produtoViewModel);
    ProdutoViewModel ConverterParaViewModel(Produto produto);
    IEnumerable<ProdutoViewModel> ConverterParaViewModel(IEnumerable<Produto> produtos);
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
        var imagemProduto = produto.ImagensProduto.FirstOrDefault();
        return new ProdutoViewModel
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            PrecoCusto = produto.PrecoCusto,
            PrecoVenda = produto.PrecoVenda,
            DataVenda = produto.DataVenda,
            Status = produto.Status,
            Excluido = produto.Excluido,
            ImagemProduto = new ImagemProdutoViewModel()
            {
                Id = imagemProduto.Id,
                NomeImagem = imagemProduto.NomeImagem,
                CaminhoArquivo = imagemProduto.CaminhoArquivo,
                ProdutoId = imagemProduto.ProdutoId,
            }
        };
    }

    public IEnumerable<ProdutoViewModel> ConverterParaViewModel(IEnumerable<Produto> produtos)
    {
        var produtosViewModel = new List<ProdutoViewModel>();

        foreach (var produto in produtos)
            produtosViewModel.Add(ConverterParaViewModel(produto));

        return produtosViewModel;
    }
}
