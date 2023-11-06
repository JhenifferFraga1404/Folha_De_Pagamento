using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly BancoContext _context;
        public FuncionarioRepositorio(BancoContext bancoContent)
        {
            this._context = bancoContent;
        }
        public ContatoModel ListarPorId(int id)
        {
            return _context.Funcionarios.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _context.Funcionarios.ToList();
        }
        public ContatoModel Adicionar(ContatoModel funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();

            return funcionario;
        }

        public ContatoModel Atualizar(ContatoModel funcionario)
        {
            ContatoModel funcionarioDB = ListarPorId(funcionario.Id);

            if (funcionarioDB == null) throw new System.Exception("Houve um erro na atualização do funcionário");

            funcionarioDB.Nome = funcionario.Nome;
            funcionarioDB.Email = funcionario.Email;
            funcionarioDB.Celular = funcionario.Celular;
            funcionarioDB.Cargo = funcionario.Cargo;

            _context.Funcionarios.Update(funcionarioDB);
            _context.SaveChanges();

            return funcionarioDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel funcionarioDB = ListarPorId(id);

            if (funcionarioDB == null) throw new System.Exception("Houve um erro da deleção do funcionário");

            _context.Funcionarios.Remove(funcionarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}
