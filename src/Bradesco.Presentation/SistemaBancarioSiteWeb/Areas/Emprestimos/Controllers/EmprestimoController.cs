using EmprestimoPessoaFisica.Application.EmprestimoGeral;
using SistemaBancarioSiteWeb.Areas.Emprestimos.Models;
using System.Linq;
using System.Web.Mvc;

namespace SistemaBancarioSiteWeb.Areas.Emprestimos.Controllers
{
    public class EmprestimoController : Controller
    {
        EmprestimoGeralService _emprestimoGeralService;

        public EmprestimoController(EmprestimoGeralService emprestimoGeralService)
        {
            _emprestimoGeralService = emprestimoGeralService;
        }

        public ActionResult Index()
        {
            var vm =  _emprestimoGeralService.Get().Select(x => new EmprestimoViewModel() {
                Data = x.DataEmprestimo,
                IdContaCorrente = x.IdContaCorrente,
                Valor = x.Valor
            });

            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CriarEmprestimoViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _emprestimoGeralService.Salvar(vm.IdContaCorrente, vm.Valor);
                return new RedirectResult("Index");
            }

            return View();
        }
    }
}