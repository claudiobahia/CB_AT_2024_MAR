using WebLivrariaAT.Models;
using Microsoft.AspNetCore.Mvc;
using WebLivrariaAT.Repositorios.Interfaces;

public class LivroController : Controller
{

    private readonly ILivroRepositorio _livroRepositorio;

    public LivroController(ILivroRepositorio livroRepositorio)
    {
        _livroRepositorio = livroRepositorio;
    }

    public IActionResult AdicionarLivro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarLivro(LivroViewModel livro)
    {

        LivroViewModel _livro = await _livroRepositorio.CriarLivro(livro);
        return RedirectToAction("Index", "Home");
    }

    [HttpDelete]
    public async Task<IActionResult> ConfirmarExclusao(int id)
    {
        bool isDeletado = await _livroRepositorio.ApagarLivro(id);
        if (isDeletado)
        {
            // Se o livro for excluído com sucesso, retorne uma resposta JSON com a URL de redirecionamento
            return Json(new { redirectUrl = Url.Action("Index", "Home") });
        }
        else
        {
            // Se a exclusão falhar, retorne uma resposta JSON indicando o erro
            return Json(new { error = "Erro ao excluir o livro" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> ApagarLivro(int livroId)
    {
        var livro = await _livroRepositorio.BuscarLivroPorId(livroId);
        return View(livro);
    }


    public IActionResult Sucesso()
    {
        return View();
    }
}
