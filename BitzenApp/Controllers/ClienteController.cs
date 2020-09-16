using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaAppApplication.Dto;
using ProvaAppApplication.Interfaces;

namespace ProvaApp.Controllers
{
    [Route("Cadastro/cliente")]
    public class ClienteController : Controller
    {
        private readonly IApplicationCliente _appCliente;

        public ClienteController(IApplicationCliente appCliente)
        {
            _appCliente = appCliente;
        }

        [HttpPost]
        [Route("adicionar")]
        public int Adicionar([FromBody] ClienteDto cliente)
        {
            return _appCliente.Adicionar(cliente);
        }

        [Route("obterTodosCliente")]
        [HttpGet]
        public IEnumerable<ClienteDto> ObterTodosCliente()
        {
            return _appCliente.ObterTodos();
        }

        [HttpPost]
        [Route("remover")]
        public int Remover([FromBody] int codigo)
        {
            return _appCliente.Remover(codigo);
        }

        [HttpGet]
        [Route("obterporid/{codigo}")]
        public ClienteDto ObterPorId(int codigo)
        {
            return _appCliente.ObterPorId(codigo);
        }

        [Route("alterar")]
        [HttpPost]
        public int Alterar([FromBody] ClienteDto cliente)
        {
            return _appCliente.Atualizar(cliente);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}