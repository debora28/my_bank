﻿using MyLastApi.Models;

namespace MyLastApi.Repositories
{
    public interface IContasRepository
    {
        Task<IEnumerable<Conta>> GetContas();
        Task<Conta> GetConta(int id);
        Task<Conta> CreateConta(Conta conta);
        Task<Conta> UpdateConta(Conta conta);
        Task DeleteConta(int id);
    }
}
