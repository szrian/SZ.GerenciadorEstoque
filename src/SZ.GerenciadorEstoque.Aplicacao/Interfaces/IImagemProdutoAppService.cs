using Microsoft.AspNetCore.Http;
using SZ.GerenciadorEstoque.Aplicacao.ViewModels;

namespace SZ.GerenciadorEstoque.Aplicacao.Interfaces;

public interface IImagemProdutoAppService
{
    Task Adicionar(IFormFile imagem, Guid produtoId);
}
