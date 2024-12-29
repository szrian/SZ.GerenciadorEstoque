using SZ.GerenciadorEstoque.Dominio.Enums;

namespace SZ.GerenciadorEstoque.Dominio.Models;

public class Produto
{
    public Produto(Guid id, 
        string nome, 
        string descricao, 
        decimal precoCusto, 
        decimal? precoVenda, 
        Status status)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        PrecoCusto = precoCusto;
        PrecoVenda = precoVenda;
        Status = status;
        Excluido = false;
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
