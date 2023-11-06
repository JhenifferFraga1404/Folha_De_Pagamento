using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IFuncionarioRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel ListarPorId(int id);
        ContatoModel Adicionar(ContatoModel funcionario);
        ContatoModel Atualizar(ContatoModel funcionario);
        bool Apagar(int id);
    }
}
