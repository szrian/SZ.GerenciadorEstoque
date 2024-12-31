using SZ.GerenciadorEstoque.Aplicacao.ViewModels;

namespace SZ.GerenciadorEstoque.Aplicacao.Interfaces;

public interface IProdutoAppService
{
    Task<ProdutoViewModel> Adicionar(ProdutoViewModel produtoViewModel);
    ProdutoViewModel Atualizar(ProdutoViewModel produtoViewModel);
    Task Remover(Guid id);
    Task<ProdutoViewModel> ObterPorIdAsync(Guid id);
}
