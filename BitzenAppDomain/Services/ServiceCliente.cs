using ProvaAppDomain.Entities;
using ProvaAppDomain.Interfaces.Repositories;
using ProvaAppDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaAppDomain.Services
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IRepositoryCliente _repoCliente;

        public ServiceCliente(IRepositoryCliente repoCliente)
        {
            _repoCliente = repoCliente;
        }

        public int Adicionar(Cliente cliente)
        {
            if (cliente == null)
                return 0;

            if (cliente.EstaConsistente())
            {
                return _repoCliente.Adicionar(cliente);
            }

            return 0;
        }

        public int Atualizar(Cliente cliente)
        {
            if (cliente.NCodCliente > 0)
                return _repoCliente.Atualizar(cliente);

            return 0;
        }

      

        public Cliente ObterPorId(int id)
        {
            if (id > 0)
                return _repoCliente.ObterPorId(id);

            return null;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _repoCliente.ObterTodos();
        }

        public int Remover(int id)
        {
            if (id > 0)
                return _repoCliente.Remover(id);

            return -1;
        }

        public void Dispose()
        {
            _repoCliente.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
