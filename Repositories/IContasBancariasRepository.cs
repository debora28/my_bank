using MyLastApi.Models;

namespace MyLastApi.Repositories
{
    public interface IContasBancariasRepository
    {
        Task<IEnumerable<ContaBancaria>> GetContas();
        Task<ContaBancaria> GetConta(int id);
        Task<ContaBancaria> CreateConta(ContaBancaria conta);
        Task<ContaBancaria> UpdateConta(ContaBancaria conta);
        Task DeleteConta(int id);
    }
}
