using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitzenAppApplication.Dto;
using BitzenAppApplication.Interfaces;
using BitzenAppDomain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitzenAppAPI.Controllers
{
    [Route("api/veiculo")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IApplicationVeiculo _appVeiculo;

        public VeiculoController(IApplicationVeiculo appVeiculo)
        {
            _appVeiculo = appVeiculo;
        }

        [HttpPost]
        [Route("adicionar")]
        public int Adicionar([FromBody] VeiculoDto veiculo)
        {
            return _appVeiculo.Adicionar(veiculo);
        }

        [HttpPost]
        [Route("alterar")]
        public int Alterar([FromBody] VeiculoDto veiculo)
        {
            return _appVeiculo.Atualizar(veiculo);
        }

        [HttpPost]
        [Route("remover")]
        public int Remover([FromBody] int codigo)
        {
            return _appVeiculo.Remover(codigo);
        }

        [HttpPost]
        [Route("obtertodosporusuario")]
        public IEnumerable<VeiculoDto> ObterTodosPorUsuario([FromBody]string usuario)
        {
            return _appVeiculo.ObterTodosPorUsuario(usuario);
        }

        [HttpGet]
        [Route("obterTodasMarca")]
        public IEnumerable<MarcaDto> ObterTodasMarca()
        {
            return _appVeiculo.ObterTodasMarca();
        }
        [HttpGet]
        [Route("obterTodosTipoVeiculo")]
        public IEnumerable<TipoVeiculoDto> ObterTodosTipoVeiculo()
        {
            return _appVeiculo.ObterTodosTipoVeiculo();
        }
        [HttpGet]
        [Route("obterTodosTipoCombustivel")]
        public IEnumerable<TipoCombustivelDto> ObterTodosTipoCombustivel()
        {
            return _appVeiculo.ObterTodosTipoCombustivel();
        }
        [HttpPost]
        [Route("obterporid")]
        public VeiculoDto ObterPorId([FromBody] int obterporid)
        {
            return _appVeiculo.ObterPorId(obterporid);
        }
        [HttpPost]
        [Route("obterTodosModeloxMarca")]
        public IEnumerable<ModeloDto> ObterTodosModeloxMarca([FromBody]int codMarca)
        {
            return _appVeiculo.ObterTodosModeloxMarca(codMarca);
        }

    }
}