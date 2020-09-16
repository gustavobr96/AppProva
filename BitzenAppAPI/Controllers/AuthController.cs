using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitzenAppApplication.Dto;
using BitzenAppApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BitzenAppAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IApplicationUsuario _appUsuario;

        public AuthController(IApplicationUsuario appUsuario)
        {
            _appUsuario = appUsuario;
        }

        [Route("login")]
        public string Login([FromBody] UsuarioDto user)
        {

            var usuario = _appUsuario.AutenticarUsuario(user);
            string login = JsonConvert.SerializeObject(usuario, Formatting.Indented);

            return login;
        }

        [HttpPost]
        [Route("adicionar")]
        public int Adicionar([FromBody] UsuarioDto user)
        {
            return _appUsuario.Adicionar(user);
        }

    }
}