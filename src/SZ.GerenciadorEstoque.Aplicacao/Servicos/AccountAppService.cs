using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using SZ.GerenciadorEstoque.Aplicacao.Interfaces;
using SZ.GerenciadorEstoque.Aplicacao.ViewModels;

namespace SZ.GerenciadorEstoque.Aplicacao.Servicos;

public class AccountAppService : IAccountAppService
{
	private readonly UserManager<IdentityUser> _userManager;
	private readonly SignInManager<IdentityUser> _signInManager;

	public async Task<string> EfetuarLogin(LoginViewModel loginVM)
	{
		var user = await _userManager.FindByEmailAsync(loginVM.UserEmail);

		if (user != null)
		{
			var result = await _signInManager.PasswordSignInAsync(user, loginVM.Senha, false, false);

			if (!result.Succeeded)
				return "Falha ao realizar o login!";

			return string.Empty;
		}

		return "Usuário não encontrado";
	}

	public async Task Logout()
		=> await _signInManager.SignOutAsync();
}
