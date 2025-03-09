namespace Web.Models
{
    public class ProjetoFuncionario
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        public int FuncionarioId { get; set; }
    }
}