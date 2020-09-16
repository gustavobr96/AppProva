using ProvaAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaAppApplication.Dto
{
    public class ClienteDto
    {

        public string NCodCliente { get;  set; }
        public string CNome { get;  set; }
        public string DNascimento { get;  set; }
        public string CSexo { get;  set; }
        public string CCep { get;  set; }
        public string CEndereco { get;  set; }
        public string NNumero { get;  set; }
        public string CComplemento { get;  set; }
        public string CEstado { get;  set; }
        public string CCidade { get;  set; }
        public string CBairro { get;  set; }

        public static explicit operator ClienteDto(Cliente c)
        {
            return new ClienteDto
            {
                NCodCliente = c.NCodCliente.ToString(),
                CNome = c.CNome,
                DNascimento = c.DNascimento.ToString(),
                CSexo = c.CSexo.ToString(),
                CCep = c.CCep,
                CEndereco = c.CEndereco,
                NNumero = c.NNumero.ToString(),
                CComplemento = c.CComplemento,
                CEstado = c.CEstado,
                CCidade = c.CCidade,
                CBairro = c.CBairro

            };
        }

    }
    
}
