using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Models;

public class FuncionarioService
{
    private readonly HttpClient _httpClient;

    public FuncionarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Funcionario> ObterFuncionarioAleatorioAsync()
    {
        var response = await _httpClient.GetStringAsync("https://randomuser.me/api/");
        using var jsonDoc = JsonDocument.Parse(response);
        var root = jsonDoc.RootElement.GetProperty("results")[0];

        return new Funcionario
        {
            Nome = root.GetProperty("name").GetProperty("first").GetString(),
            Sobrenome = root.GetProperty("name").GetProperty("last").GetString(),
            Email = root.GetProperty("email").GetString()
        };
    }
}