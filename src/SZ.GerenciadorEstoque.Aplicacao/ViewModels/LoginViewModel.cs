using System.ComponentModel.DataAnnotations;

namespace SZ.GerenciadorEstoque.Aplicacao.ViewModels;

public class LoginViewModel
{
	[Required(ErrorMessage = "Informe o Email")]
	[Display(Name = "Email")]
	public string UserEmail { get; set; }

	[Required(ErrorMessage = "Informe a Senha")]
	[DataType(DataType.Password)]
	[Display(Name = "Senha")]
	public string Senha { get; set; }
	public string UrlRetorno { get; set; }
}
