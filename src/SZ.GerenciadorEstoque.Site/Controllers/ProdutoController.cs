using Microsoft.AspNetCore.Mvc;

namespace SZ.GerenciadorEstoque.Site.Controllers
{
    public class ProdutoController : Controller
    {
        public ProdutoController()
        { }

        public async Task<IActionResult> Index()
        {
            var produtosViewModel = new List<ProdutoViewModel>();

            return View(produtosViewModel);
        }

        public async Task<IActionResult> Detalhes(Guid? id)
        {
            if (id == null) NotFound();

            var produtoViewModel = await _produtoAppService.ObterPorIdAsync(id);

            if (produtoViewModel == null) NotFound();

            return View(produtoViewModel);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(ProdutoViewModel produtoViewModel)
        {
            //Implementar método
        }

        public async Task<IActionResult> Atualizar(Guid? id)
        {
            if (id == null) NotFound();

            var produto = await _produtoAppService.ObterPorIdAsync(id);

            if (produto == null)NotFound();

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) NotFound();

            if (!ModelState.IsValid)
                return View(produtoViewModel);

            await _produtoAppService.Atualizar(produtoViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(Guid? id)
        {
            if (id == null) NotFound();

            var produtoViewModel = await _produtoAppService.ObterPorIdAsync(id);

            if (produtoViewModel == null) NotFound();

            return View(produtoViewModel);
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
