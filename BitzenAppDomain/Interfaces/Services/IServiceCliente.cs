using ProvaAppDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaAppDomain.Interfaces.Services
{
    public interface IServiceCliente: IDisposable
    {
        int Adicionar(Cliente cliente);
        int Atualizar(Cliente cliente);
        int Remover(int id);
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorId(int id);
    }
}
