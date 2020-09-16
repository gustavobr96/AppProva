using ProvaAppApplication.Dto;
using ProvaAppApplication.Interfaces;
using ProvaAppDomain.Entities;
using ProvaAppDomain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvaAppApplication.Services
{
    public class ApplicationCliente : IApplicationCliente
    {
        private readonly IServiceCliente _serviceCliente;

        public ApplicationCliente(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        public int Adicionar(ClienteDto entity)
        {
            Cliente cliente = new Cliente();
            cliente.PrepararDadosParaInserir(entity.CNome, entity.DNascimento, entity.CSexo, entity.CCep, entity.CEndereco, entity.NNumero, entity.CComplemento, entity.CEstado, entity.CCidade, entity.CBairro);
            return _serviceCliente.Adicionar(cliente);
        }

        public int Atualizar(ClienteDto entity)
        {
            Cliente cliente = new Cliente();
            cliente.PrepararDadosParaAtualizar(entity.NCodCliente,entity.CNome, entity.DNascimento, entity.CSexo, entity.CCep, entity.CEndereco, entity.NNumero, entity.CComplemento, entity.CEstado, entity.CCidade, entity.CBairro);
            return _serviceCliente.Atualizar(cliente);
        }

        public ClienteDto ObterPorId(int id)
        {
            return (ClienteDto)_serviceCliente.ObterPorId(id);
        }

        public IEnumerable<ClienteDto> ObterTodos()
        {
            var con = _serviceCliente.ObterTodos();
            return con.Select(e => (ClienteDto)e);
        }

        public int Remover(int id)
        {
            return _serviceCliente.Remover(id);
        }
        public void Dispose()
        {
            _serviceCliente.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
