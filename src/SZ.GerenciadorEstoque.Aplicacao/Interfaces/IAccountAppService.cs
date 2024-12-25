using SZ.GerenciadorEstoque.Aplicacao.ViewModels;

namespace SZ.GerenciadorEstoque.Aplicacao.Interfaces;

public interface IAccountAppService
{
	Task<string> EfetuarLogin(LoginViewModel loginVM);
	Task Logout();
}
