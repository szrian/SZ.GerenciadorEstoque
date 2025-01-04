using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using SZ.GerenciadorEstoque.Dominio.Enums;

namespace SZ.GerenciadorEstoque.Aplicacao.ViewModels;

public class ProdutoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    [DisplayName("Descrição")]
    public string Descricao { get; set; }

    [DisplayName("Custo")]
    public decimal PrecoCusto { get; set; }

    [DisplayName("Preço")]
    public decimal? PrecoVenda { get; set; }

    [DisplayName("Vendido em")]
    public DateTime? DataVenda { get; set; }
    public Status Status { get; set; }
    public IFormFile Imagem { get; set; }
    public bool Excluido { get; set; }
}
