using Microsoft.AspNetCore.Mvc;
using SZ.GerenciadorEstoque.Aplicacao.Interfaces;
using SZ.GerenciadorEstoque.Aplicacao.ViewModels;

namespace SZ.GerenciadorEstoque.Site.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountAppService _accountAppService;
		public AccountController(IAccountAppService accountAppService)
		{
			_accountAppService = accountAppService;
		}

		public IActionResult Login(string urlRetorno)
		{
			return View(new LoginViewModel()
			{
				UrlRetorno = urlRetorno
			});
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginVM)
		{
			if (!ModelState.IsValid) return View(loginVM);

			var retorno = await _accountAppService.EfetuarLogin(loginVM);

			if (retorno != string.Empty)
			{
				ModelState.AddModelError(string.Empty, retorno);
				return View(loginVM);
			}

			if (string.IsNullOrEmpty(loginVM.UrlRetorno)) return RedirectToAction("Index", "Produto");

			return Redirect(loginVM.UrlRetorno);
		}

		[HttpPost]
		public async Task<IActionResult> Logout()
		{
			HttpContext.Session.Clear();
			HttpContext.User = null;
			await _accountAppService.Logout();

			return RedirectToAction("Login", "Account");
		}
	}
}
