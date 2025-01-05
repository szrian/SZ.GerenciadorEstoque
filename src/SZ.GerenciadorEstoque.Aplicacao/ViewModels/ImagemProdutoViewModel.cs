namespace SZ.GerenciadorEstoque.Aplicacao.ViewModels;

public class ImagemProdutoViewModel
{
    public Guid Id { get; set; }
    public string NomeImagem { get; set; }
    public string CaminhoArquivo { get; set; }
    public Guid ProdutoId { get; set; }
}
