using Microsoft.EntityFrameworkCore;
using MyLastApi.Model;
using MyLastApi.Models;
using System;

namespace MyLastApi.Migrations
{
    public class ContasContext : DbContext
    {
        public ContasContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        //Para cada entidade, criar um dbset:
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ContaBancaria> Contas { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }

        //Aqui se especifica qual a chave primária e outras definições de banco:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Criando as entidades:
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<ContaBancaria>().HasKey(c => c.IdConta);
            modelBuilder.Entity<Operacao>().HasKey(c => c.IdOperacao);

            //Alimentando as tabelas (seeding): 
            modelBuilder.Entity<Usuario>().HasData(
                new
                {
                    Id = 1,
                    Nome = "Admin",
                    Cpf = "08995228407",
                    DataNasc = new DateTime(1992, 01, 23)
                },
                new
                {
                    Id = 2,
                    Nome = "Fatima",
                    Cpf = "60671150006",
                    DataNasc = new DateTime(1963, 05, 04)
                },
                new
                {
                    Id = 3,
                    Nome = "Orlando",
                    Cpf = "47633984074",
                    DataNasc = new DateTime(1980, 12, 31)
                }
                );
            modelBuilder.Entity<ContaBancaria>().HasData(
                new
                {
                    IdConta = 1,
                    ClienteId = 1,
                    CpfCliente = "08995228407",
                    Agencia = "0123",
                    NumConta = "0123",
                    Saldo = 0m,
                    Ativa =  true,
                    Bloqueada = false,
                    LimiteDiario = 0m
                },
                new
                {
                    IdConta = 2,
                    ClienteId = 2,
                    CpfCliente = "60671150006",
                    Agencia = "0123",
                    NumConta = "0124",
                    Saldo = 0m,
                    Ativa = true,
                    Bloqueada = false,
                    LimiteDiario = 0m
                },
                new
                {
                    IdConta = 3,
                    ClienteId = 3,
                    CpfCliente = "47633984074",
                    Agencia = "0123",
                    NumConta = "0125",
                    Saldo = 0m,
                    Ativa = true,
                    Bloqueada = false,
                    LimiteDiario = 0m
                });
        }
    }
}
