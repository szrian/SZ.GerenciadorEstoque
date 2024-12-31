using SZ.GerenciadorEstoque.Dominio.Enums;

namespace SZ.GerenciadorEstoque.Dominio.Models;

public class Produto
{
    public Produto(string nome,
        string descricao, 
        decimal precoCusto,
        Status status)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        PrecoCusto = precoCusto;
        Status = status;
        Excluido = false;
    }

    public Produto(Guid id,
        string nome,
        string descricao,
        decimal precoCusto,
        decimal? precoVenda,
        DateTime? dataVenda,
        Status status,
        bool excluido)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        PrecoCusto = precoCusto;
        PrecoVenda = precoVenda;
        DataVenda = dataVenda;
        Status = status;
        Excluido = excluido;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal PrecoCusto { get; private set; }
    public decimal? PrecoVenda { get; private set; }
    public DateTime? DataVenda { get; private set; }
    public Status Status { get; private set; }
    public bool Excluido { get; private set; }

    public virtual ICollection<ImagemProduto> ImagensProduto { get; set; }
}
