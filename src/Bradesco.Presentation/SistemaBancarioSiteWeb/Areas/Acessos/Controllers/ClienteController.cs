using ControleAcesso.Application.Cliente;
using ControleAcesso.Application.Cliente.Dto;
using SharedKernel.EventHandlers;
using SistemaBancarioSiteWeb.Areas.Acessos.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SistemaBancarioSiteWeb.Areas.Acessos.Controllers
{
    public class ClienteController : Controller
    {
        ClienteService _clienteService;
        ExceptionEventHandler _exceptionsEventHandler;

        public ClienteController(ClienteService clienteService,
                                 ExceptionEventHandler exceptionsEventHandler)
        {
            _clienteService = clienteService;
            _exceptionsEventHandler = exceptionsEventHandler;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var clientes = _clienteService.Get().Select(x => new ClienteViewModel() {
                IdCliente = x.Id,
                Cpf = x.Cpf,
                Nome = x.Nome
            });

            return View(clientes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateClienteViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new ClienteDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = vm.Nome,
                    Cpf = vm.Cpf,
                    Bairro = vm.Bairro,
                    Cidade = vm.Cidade,
                    Descricao = vm.Descricao,
                    Estado = vm.Estado,
                    NomeMae = vm.NomeMae,
                    Numero = vm.Numero
                };

                _clienteService.Create(dto);

                if (_exceptionsEventHandler.HasError())
                {
                    foreach (var item in _exceptionsEventHandler.Get())
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }
                    
                    return View();
                }

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}