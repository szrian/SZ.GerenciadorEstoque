using SZ.GerenciadorEstoque.Dominio.Enums;

namespace SZ.GerenciadorEstoque.Aplicacao.ViewModels;

public class ProdutoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal PrecoCusto { get; set; }
    public decimal? PrecoVenda { get; set; }
    public DateTime? DataVenda { get; set; }
    public Status Status { get; set; }
    public bool Excluido { get; set; }
}
