using ProvaAppApplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaAppApplication.Interfaces
{
    public interface IApplicationCliente : IDisposable
    {
        int Adicionar(ClienteDto entity);
        int Atualizar(ClienteDto entity);
        ClienteDto ObterPorId(int id);
        IEnumerable<ClienteDto> ObterTodos();
        int Remover(int id);
    }
}
