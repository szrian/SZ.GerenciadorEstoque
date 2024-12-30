using SZ.GerenciadorEstoque.Dominio.Interfaces.Repositorios;
using SZ.GerenciadorEstoque.Dominio.Interfaces.Servicos;
using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Dominio.Servicos;

public class ProdutoServico : IProdutoServico
{
    private readonly IRepositorioBase<Produto> _produtoRepositorio;

    public ProdutoServico(IRepositorioBase<Produto> produtoRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
    }

    public async Task<Produto> Adicionar(Produto produto)
    {
        //Validar entidade adicionada
        //Se valida, adiciona
        if (false)
            return produto;

        await _produtoRepositorio.AdicionarAsync(produto);
        return produto;
    }

    public Produto Atualizar(Produto produto)
    {
        //Validar entidade atualizada
        //Se valida, atualiza
        if (false)
            return produto;

        _produtoRepositorio.Atualizar(produto);
        return produto;
    }
}
