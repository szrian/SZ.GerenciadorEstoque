using Microsoft.AspNetCore.Http;
using SZ.GerenciadorEstoque.Aplicacao.Configuracoes;
using SZ.GerenciadorEstoque.Aplicacao.Conversores;
using SZ.GerenciadorEstoque.Aplicacao.Interfaces;
using SZ.GerenciadorEstoque.Aplicacao.ViewModels;
using SZ.GerenciadorEstoque.Dominio.Interfaces.Repositorios;
using SZ.GerenciadorEstoque.Dominio.Models;

namespace SZ.GerenciadorEstoque.Aplicacao.Servicos;

public class ImagemProdutoAppService : IImagemProdutoAppService
{
    private readonly ImagemConfiguracao _imagemConfiguracao;
    private readonly IRepositorioBase<ImagemProduto> _imagemProdutoRepositorio;
    private readonly IImagemProdutoConversor _imagemProdutoConversor;

    public ImagemProdutoAppService(ImagemConfiguracao imagemConfiguracao,
        IRepositorioBase<ImagemProduto> imagemProdutoRepositorio,
        IImagemProdutoConversor imagemProdutoConversor)
    {
        _imagemConfiguracao = imagemConfiguracao;
        _imagemProdutoRepositorio = imagemProdutoRepositorio;
        _imagemProdutoConversor = imagemProdutoConversor;
    }

    public async Task Adicionar(IFormFile imagem, Guid produtoId)
    {
        var caminhoArquivo = SalvarImagem(imagem, produtoId);
        var imagemProduto = _imagemProdutoConversor.ConverterParaEntidade(
            new ImagemProdutoViewModel()
            {
                NomeImagem = imagem.FileName,
                CaminhoArquivo = caminhoArquivo,
                ProdutoId = produtoId
            });

        await _imagemProdutoRepositorio.AdicionarAsync(imagemProduto);
    }

    private string SalvarImagem(IFormFile imagem, Guid produtoId)
    {
        var diretorio = Path.Combine(Directory.GetCurrentDirectory(),
            _imagemConfiguracao.DiretorioImagens,
            "produtos",
            produtoId.ToString());

        if (!Directory.Exists(diretorio))
            Directory.CreateDirectory(diretorio);

        var diretorioImagem = Path.Combine(diretorio, imagem.FileName);

        using (var stream = new FileStream(diretorioImagem, FileMode.Create))
        {
            imagem.CopyTo(stream);
        }

        return string.Format(@"\{0}\{1}\{2}\{3}",
            "images",
            "produtos",
            produtoId,
            imagem.FileName);
    }
}
