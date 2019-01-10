using MovimentacoesGerais.Application.Commands;
using MovimentacoesGerais.Application.ContaCorrente;
using MovimentacoesGerais.Application.ContaCorrente.Commands;
using SistemaBancarioSiteWeb.Areas.ContaCorrente.Models;
using System;
using System.Web.Mvc;

using SharedKernel.EventHandlers;

namespace SistemaBancarioSiteWeb.Areas.ContaCorrente.Controllers
{
    public class ContaCorrenteController : Controller
    {
        ContaCorrenteService _contaCorrenteService;
        ExceptionEventHandler _exceptionEventHandler;

        public ContaCorrenteController(ContaCorrenteService contaCorrenteService,
            ExceptionEventHandler exceptionEventHandler)
        {
            _contaCorrenteService = contaCorrenteService;
            _exceptionEventHandler = exceptionEventHandler;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Detail(Guid? idContaCorrente)
        {
            if (idContaCorrente.HasValue)
            {
                var contaCorrente = _contaCorrenteService.Get(idContaCorrente.Value);
                var vm = new ContaCorrenteViewModel()
                {
                    IdCliente = contaCorrente.IdCliente,
                    IdContaCorrente = contaCorrente.Id,
                    NumeroAgencia = contaCorrente.NumeroAgencia,
                    NumeroConta = contaCorrente.NumeroConta,
                    Saldo = contaCorrente.Saldo
                };
                return View(vm);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CriarContaCorrenteViewModel vm)
        {   
            if (ModelState.IsValid)
            {
                var command = new CriarCommand(vm.NumeroAgencia, vm.IdCliente);
                _contaCorrenteService.Execute(command);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Sacar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sacar(SacarViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var command = new SacarCommand(vm.IdContaCorrente, vm.Valor);
                _contaCorrenteService.Execute(command);

                if (_exceptionEventHandler.HasError())
                {
                    foreach (var item in _exceptionEventHandler.Get())
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    return View();
                }

                return RedirectToAction("Detail", new { idContaCorrente = vm.IdContaCorrente });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Depositar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Depositar(DepositarViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var command = new DepositarCommand(vm.IdContaCorrente, vm.Valor);
                _contaCorrenteService.Execute(command);

                return RedirectToAction("Detail", new { idContaCorrente = vm.IdContaCorrente });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Encerrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Encerrar(EncerrarViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Detail", vm.IdContaCorrente);
            }
            return View();
        }
    }
}