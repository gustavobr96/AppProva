using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Entities.Base
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            ListaErros = new List<string>();
        }

        public List<string> ListaErros { get; set; }
        public string Message { get; set; }
        public abstract bool EstaConsistente();
    }
}
