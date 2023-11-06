using ControleDeContatos.Filters;
using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class Contato : Controller
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public Contato(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> funcionarios = _funcionarioRepositorio.BuscarTodos();
            return View(funcionarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ContatoModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel funcionario = _funcionarioRepositorio.ListarPorId(id);
            return View(funcionario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _funcionarioRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Funcionário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu funcionário!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu funcionário, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel funcionario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepositorio.Adicionar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }


                return View(funcionario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrado o funcionário, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel funcionario)
        {
          try
            {
                if (ModelState.IsValid)
                {
                    _funcionarioRepositorio.Atualizar(funcionario);
                    TempData["MensagemSucesso"] = "Funcionário alterado com sucesso";
                    return RedirectToAction("Index");
                }


                return View("Editar", funcionario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu funcionário, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
