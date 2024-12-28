namespace SZ.GerenciadorEstoque.Dominio.Models;

public class ImagemProduto
{
    public ImagemProduto(Guid id, 
        string nomeImagem,
        string caminhoArquivo,
        Guid produtoId)
    {
        Id = id;
        NomeImagem = nomeImagem;
        CaminhoArquivo = caminhoArquivo;
        ProdutoId = produtoId;
        Excluido = false;
    }

    public Guid Id { get; private set; }
    public string NomeImagem { get; private set; }
    public string CaminhoArquivo { get; private set; }
    public bool Excluido { get; private set; }
    public Guid ProdutoId { get; private set; }

    public virtual Produto Produto { get; set; }
}
