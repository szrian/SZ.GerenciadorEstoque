using SZ.GerenciadorEstoque.Aplicacao.ViewModels;
using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Aplicacao.Conversores;

public interface IImagemProdutoConversor
{
    ImagemProduto ConverterParaEntidade(ImagemProdutoViewModel viewModel);
    ImagemProdutoViewModel ConverterParaViewModel(ImagemProduto entidade);
}
public class ImagemProdutoConversor : IImagemProdutoConversor
{
    public ImagemProduto ConverterParaEntidade(ImagemProdutoViewModel viewModel)
        => new(Guid.NewGuid(),
            viewModel.NomeImagem,
            viewModel.CaminhoArquivo,
            viewModel.ProdutoId);

    public ImagemProdutoViewModel ConverterParaViewModel(ImagemProduto entidade)
        => new ImagemProdutoViewModel
        {
            Id = entidade.Id,
            NomeImagem = entidade.NomeImagem,
            CaminhoArquivo = entidade.CaminhoArquivo,
            ProdutoId = entidade.ProdutoId
        };
}
