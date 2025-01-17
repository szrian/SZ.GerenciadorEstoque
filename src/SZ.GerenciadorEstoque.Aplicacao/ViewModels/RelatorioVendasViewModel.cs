namespace SZ.GerenciadorEstoque.Aplicacao.ViewModels;

public class RelatorioVendasViewModel
{
    public List<ProdutoViewModel> Produtos { get; set; }
    public decimal TotalGasto { get; set; }
    public decimal TotalGanho { get; set; }
    public decimal Lucro { get; set; }
}
