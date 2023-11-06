using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Digite o nome do funcionário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do funcionário")]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Digite o celular do funcionário")]
        [Phone(ErrorMessage ="Celular inválido")]
        public string Celular { get; set;}
        [Required(ErrorMessage = "Digite o cargo do funcionário")]
        public string Cargo { get; set;}

    }
}
