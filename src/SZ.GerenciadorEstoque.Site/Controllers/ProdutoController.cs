using Microsoft.AspNetCore.Mvc;
using SZ.GerenciadorEstoque.Aplicacao.Interfaces;
using SZ.GerenciadorEstoque.Aplicacao.ViewModels;

namespace SZ.GerenciadorEstoque.Site.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        public async Task<IActionResult> Index()
        {
            var produtosViewModel = new List<ProdutoViewModel>();

            return View(produtosViewModel);
        }

        public async Task<IActionResult> Detalhes(Guid? id)
        {
            if (id == null) NotFound();

            var produtoViewModel = await _produtoAppService.ObterPorIdAsync(id.Value);

            if (produtoViewModel == null) NotFound();

            return View("Details", produtoViewModel);
        }

        public IActionResult Adicionar()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(ProdutoViewModel produtoViewModel)
        {
            //Implementar método
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Atualizar(Guid? id)
        {
            if (id == null) NotFound();

            var produto = await _produtoAppService.ObterPorIdAsync(id.Value);

            if (produto == null)NotFound();

            return View("Edit", produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) NotFound();

            if (!ModelState.IsValid)
                return View(produtoViewModel);

            _produtoAppService.Atualizar(produtoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(Guid? id)
        {
            if (id == null) NotFound();

            var produtoViewModel = await _produtoAppService.ObterPorIdAsync(id.Value);

            if (produtoViewModel == null) NotFound();

            return View("Delete", produtoViewModel);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExclusaoConfirmada(Guid id)
        {
            await _produtoAppService.Remover(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
