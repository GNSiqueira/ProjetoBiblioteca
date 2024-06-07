using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class EmprestimoModel
    {
        //modelo do banco de dados
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o campo do recebedor")]
        public string Recebedor { get; set; }
		[Required(ErrorMessage = "Digite o campo do fornecedor")]
		public string Fornecedor { get; set; }
		[Required(ErrorMessage = "Digite o nome do livro")]
		public string LivroEmprestado { get; set; }
        public DateTime DataRecebedor { get; set; } = DateTime.Now; //data atual
    }
}
