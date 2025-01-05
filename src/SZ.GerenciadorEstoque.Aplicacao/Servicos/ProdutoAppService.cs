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
    private readonly IImagemProdutoAppService _imagemProdutoAppService;

    public ProdutoAppService(IProdutoServico produtoServico,
        IRepositorioBase<Produto> produtoRepositorio,
        IProdutoConversor produtoConversor,
        IImagemProdutoAppService imagemProdutoAppService)
    {
        _produtoServico = produtoServico;
        _produtoRepositorio = produtoRepositorio;
        _produtoConversor = produtoConversor;
        _imagemProdutoAppService = imagemProdutoAppService;
    }

    public async Task<ProdutoViewModel> Adicionar(ProdutoViewModel produtoViewModel)
    {
        var produto = _produtoConversor.ConverterParaEntidadeAdicionar(produtoViewModel);
        var produtoAdicionado = await _produtoServico.Adicionar(produto);

        //Valida se produto foi adicionado e existe imagem para adicionar
        if (produtoViewModel.Imagem.Length > 0)
            await _imagemProdutoAppService.Adicionar(produtoViewModel.Imagem, produtoAdicionado.Id);

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

    public async Task<IEnumerable<ProdutoViewModel>> ObterTodosAsync()
    {
        var produtos = await _produtoRepositorio.ObterTodosAsync();

        return _produtoConversor.ConverterParaViewModel(produtos);
    }

    public async Task Remover(Guid id) =>
        await _produtoRepositorio.Remover(id);
}
