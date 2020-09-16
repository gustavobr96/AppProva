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
    [Route("api/relatorio")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IApplicationRelatorio _appRelatorio;

        public RelatorioController(IApplicationRelatorio appRelatorio)
        {
            _appRelatorio = appRelatorio;
        }

        [HttpPost]
        [Route("obterrelatorioporusuariotipos")]
        public RelatorioDto ObterRelatorioPorUsuarioTipos([FromBody] RelatorioDto r)
        {
            return _appRelatorio.ObterRelatorioPorUsuarioTipos(r.usuario,r.Tipo);
        }
      


    }
}