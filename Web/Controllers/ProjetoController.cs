using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Web.Data;
using Web.Models;
using System.Net.Http;
using System.Text.Json;

namespace Web.Controllers
{
    public class ProjetoController : Controller
    {

        readonly private ApplicationDbContext _db;
        readonly private HttpClient _httpClient;

        public ProjetoController(ApplicationDbContext db)
        {
            _db = db;
            _httpClient = new HttpClient();
        }


        public IActionResult Index()
        {
            IEnumerable<Projeto> projetos = _db.Projetos;
            return View(projetos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            Projeto projeto = _db.Projetos.FirstOrDefault(x => x.Id == id);

            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projetos)
        {
            if (ModelState.IsValid)
            {
                _db.Projetos.Add(projetos);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]

        public IActionResult Editar(Projeto projetos)
        {
            if (ModelState.IsValid)
            {
                _db.Projetos.Update(projetos);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(projetos);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Projeto projeto = _db.Projetos.FirstOrDefault(x => x.Id == id);

            if (projeto.Status == "Iniciado" || projeto.Status == "Em andamento" || projeto.Status == "Encerrado")
            {
                TempData["Erro"] = "Este projeto não pode ser excluído porque já foi iniciado, está em andamento ou encerrado.";
                return RedirectToAction("Index");
            }

            if (projeto == null)
            {
                return NotFound();
            }

            return View(projeto);
        }

        [HttpPost]
        public IActionResult Excluir(Projeto projetos)
        {
            if(projetos == null)
            {
                return NotFound();
            }


            _db.Projetos.Remove(projetos);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> VincularFuncionario(int id)
        {
            var projeto = _db.Projetos.FirstOrDefault(x => x.Id == id);
            if (projeto == null) return NotFound();

            // Chama a API para obter um funcionário aleatório
            var response = await _httpClient.GetStringAsync("https://randomuser.me/api/");
            var data = JsonSerializer.Deserialize<JsonElement>(response);
            var funcionarioId = data.GetProperty("info").GetProperty("seed").GetString().GetHashCode(); // Simulação de ID único

            var projetoFuncionario = new ProjetoFuncionario
            {
                ProjetoId = id,
                FuncionarioId = funcionarioId
            };

            _db.Set<ProjetoFuncionario>().Add(projetoFuncionario);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
