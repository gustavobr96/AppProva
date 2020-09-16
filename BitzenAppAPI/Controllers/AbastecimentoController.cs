using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitzenAppApplication.Dto;
using BitzenAppApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitzenAppAPI.Controllers
{
    [Route("api/abastecimento")]
    [ApiController]
    public class AbastecimentoController : ControllerBase
    {
        private readonly IApplicationAbastecimento _appAbastecimento;

        public AbastecimentoController(IApplicationAbastecimento appAbastecimento)
        {
            _appAbastecimento = appAbastecimento;
        }

        [HttpPost]
        [Route("obtertodosporusuario")]
        public IEnumerable<AbastecimentoDto> ObterTodosPorUsuario([FromBody]string usuario)
        {
            return _appAbastecimento.ObterTodosPorUsuario(usuario);
        }

        [HttpGet]
        [Route("obterTodosPosto")]
        public IEnumerable<PostoDto> ObterTodosPosto()
        {
            return _appAbastecimento.ObterTodosPosto();
        }

        [HttpPost]
        [Route("adicionar")]
        public int Adicionar([FromBody] AbastecimentoDto abastecimento)
        {
            return _appAbastecimento.Adicionar(abastecimento);
        }

        [HttpPost]
        [Route("alterar")]
        public int Alterar([FromBody] AbastecimentoDto abastecimento)
        {
            return _appAbastecimento.Atualizar(abastecimento);
        }

        [HttpPost]
        [Route("remover")]
        public int Remover([FromBody] int codigo)
        {
            return _appAbastecimento.Remover(codigo);
        }
        [HttpPost]
        [Route("obterporid")]
        public AbastecimentoDto ObterPorId([FromBody] int obterporid)
        {
            return _appAbastecimento.ObterPorId(obterporid);
        }


    }
}