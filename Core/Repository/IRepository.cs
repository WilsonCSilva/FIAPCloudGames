﻿using Core.Entity;

namespace Core.Repository
{
    /// <summary>
    /// CRUD
    /// </summary>
    public interface IRepository<T> where T : EntityBase
    {
        IList<T> ObterTodos();
        T ObterPorId(int id);
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Deletar(int id);
    }
}
