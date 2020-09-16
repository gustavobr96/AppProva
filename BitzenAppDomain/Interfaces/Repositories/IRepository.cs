using System;
using System.Collections.Generic;
using System.Text;

namespace BitzenAppDomain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        int Adicionar(TEntity entity);
        int Atualizar(TEntity entity);
        int Remover(int id);
        IEnumerable<TEntity> ObterTodos();
        TEntity ObterPorId(int id);
    }
}
