using SZ.GerenciadorEstoque.Aplicacao.Conversores;
using SZ.GerenciadorEstoque.Aplicacao.Interfaces;
using SZ.GerenciadorEstoque.Aplicacao.ViewModels;
using SZ.GerenciadorEstoque.Dominio.Interfaces.Repositorios;
using SZ.GerenciadorEstoque.Dominio.Interfaces.Servicos;
using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Aplicacao.Servicos;

public class ProdutoAppService : IProdutoAppService
{
    private readonly IProdutoServico _produtoServico;
    private readonly IRepositorioBase<Produto> _produtoRepositorio;
    private readonly IProdutoConversor _produtoConversor;

    public ProdutoAppService(IProdutoServico produtoServico,
        IRepositorioBase<Produto> produtoRepositorio,
        IProdutoConversor produtoConversor)
    {
        _produtoServico = produtoServico;
        _produtoRepositorio = produtoRepositorio;
        _produtoConversor = produtoConversor;
    }

    public async Task<ProdutoViewModel> Adicionar(ProdutoViewModel produtoViewModel)
    {
        var produto = _produtoConversor.ConverterParaEntidadeAdicionar(produtoViewModel);
        var produtoAdicionado = await _produtoServico.Adicionar(produto);

        return _produtoConversor.ConverterParaViewModel(produtoAdicionado);
    }

    public ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel)
    {
        var produto = _produtoConversor.ConverterParaEntidadeAtualizar(produtoViewModel);
        var produtoAtualizado = _produtoServico.Atualizar(produto);

        return _produtoConversor.ConverterParaViewModel(produtoAtualizado);
    }

    public async Task<ProdutoViewModel> ObterPorIdAsync(Guid id)
    {
        var produto = await _produtoRepositorio.ObterPorIdAsync(id);

        return _produtoConversor.ConverterParaViewModel(produto);
    }

    public async Task Remover(Guid id) =>
        await _produtoRepositorio.Remover(id);
}
