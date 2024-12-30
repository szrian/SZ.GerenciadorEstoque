using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Dominio.Interfaces.Servicos;

public interface IProdutoServico
{
    Task<Produto> Adicionar(Produto produto);
    Produto Atualizar(Produto produto);
}
