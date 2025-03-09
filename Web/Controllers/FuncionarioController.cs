using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class FuncionarioController : Controller
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionarioController(FuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    public async Task<IActionResult> Index()
    {
        var funcionario = await _funcionarioService.ObterFuncionarioAleatorioAsync();
        return View(funcionario);
    }
}