using Microsoft.EntityFrameworkCore;
using MyLastApi.Migrations;
using MyLastApi.Models;

namespace MyLastApi.Repositories
{
    public class ContasBancariasRepository : IContasBancariasRepository
    {
        public readonly ContasContext DbContext;

        public ContasBancariasRepository(ContasContext context)
        {
            DbContext = context;
        }
        public async Task<IEnumerable<ContaBancaria>> GetContas()
        {
            return await DbContext.Contas.ToListAsync();
        }

        public async Task<ContaBancaria> GetConta(int IdConta)
        {
            var conta = await DbContext.Contas.FindAsync(IdConta);
            if (conta == null)
            {
                throw new Exception();
            }
            else
            {
                return conta;
            }
        }

        public async Task<ContaBancaria> CreateConta(ContaBancaria conta)
        {
            DbContext.Contas.Add(conta);
            await DbContext.SaveChangesAsync();
            return conta;
        }

        public async Task<ContaBancaria> UpdateConta(ContaBancaria conta)
        {
            DbContext.Entry(conta).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return conta;
        }

        public async Task DeleteConta(int IdConta)
        {
            var conta = DbContext.Contas.Find(IdConta);
            if(conta == null)
            {
                throw new Exception();
            } else
            {
                DbContext.Contas.Remove(conta);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
