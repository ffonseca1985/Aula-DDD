using CQRSlite.Config;
using SistemaBancarioSiteWeb.App_Start;
using SistemaBancarioSiteWeb.Areas.Vendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vendas.Application.Venda;
using Vendas.CommandHandlers;
using Vendas.Commands;
using VendasQueryStack.Application.Venda;
using VendasQueryStack.Infrastructure.Repositories.Dtos;

namespace SistemaBancarioSiteWeb.Areas.Vendas.Controllers
{
    public class VendaController : Controller
    {
        VendaCdbService _vendaQueryService;
        VendaService _vendaService;

        public VendaController(VendaCdbService vendaQueryService,
            VendaService vendaService)
        {
            _vendaQueryService = vendaQueryService;
            _vendaService = vendaService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<VendaCDBDto> query = await _vendaQueryService.Get();

            var vm = query.Select(x => new VendaViewModel() {
                Descricao = "",
                IdContaCorrente = Guid.NewGuid(),
                Valor = 20
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
        public ActionResult Create(CriarVendaViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //CQRSLite
                var register = new BusRegistrar(new CustomDependencyResolverMvc());
                register.Register(typeof(VendaCommandHandler));

                var command = new VenderCDBCommand(vm.IdProdutoFinanceiro, vm.IdContaCorrente, 0);
                _vendaService.Executar(command);

                return new RedirectResult("Index");
            }

            return View();
        }

    }
}