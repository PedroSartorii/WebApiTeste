using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do projeto!")]
        public String Nome { get; set; }
        [Required(ErrorMessage = "Digite a descrição do projeto!")]
        public String Descricao { get; set; }
        [Required(ErrorMessage = "Digite a data de início do projeto!")]
        public DateOnly Data_inicio { get; set; }
        [Required(ErrorMessage = "Digite a data de finalização do projeto!")]
        public DateOnly Data_final { get; set; }
        [Required(ErrorMessage = "Escolha o Status do projeto!")]
        public String Status { get; set; }
        [Required(ErrorMessage = "Escolha o Risco do projeto!")]
        public String Risco { get; set; }
        public int Id_funcionario { get; set; }

        public List<ProjetoFuncionario> Funcionarios { get; set; } = new List<ProjetoFuncionario>();
    }
}
