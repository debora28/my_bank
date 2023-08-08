using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MyLastApi.Model;
using MyLastApi.Models;
using System;

namespace MyLastApi.Migrations
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions options) : base(options)
        {
                Database.EnsureCreated();
            //try
            //{
            //}
            //catch
            //{
            //    Console.WriteLine("Erro na classe ou no DBContext");
            //}
        }

        //Para cada entidade, criar um dbset:
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }

        //Aqui se especifica qual a chave primária e outras definições de banco:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Criando as entidades:
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);
            modelBuilder.Entity<Conta>().HasKey(c => c.IdConta);
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
            modelBuilder.Entity<Conta>().HasData(
                new
                {
                    IdConta = 1,
                    ClienteId = 1,
                    CpfCliente = "08995228407",
                    Agencia = "0123",
                    NumConta = 1,
                    Saldo = 0m,
                    Ativa = true,
                    Bloqueada = false,
                    LimiteDiario = 0m
                },
                new
                {
                    IdConta = 2,
                    ClienteId = 2,
                    CpfCliente = "60671150006",
                    Agencia = "0123",
                    NumConta = 2,
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
                    NumConta = 3,
                    Saldo = 0m,
                    Ativa = true,
                    Bloqueada = false,
                    LimiteDiario = 0m
                });
            modelBuilder.Entity<Operacao>().HasData(
            new
            {
                IdOperacao = 1,
                TipoOperacao = "Depósito",
                DataOperacao = new DateTime(),
                //Versao = 1,
                Valor = 8798.13m,
                IdConta = 1
            },
            new
            {
                IdOperacao = 2,
                TipoOperacao = "Saque",
                DataOperacao = new DateTime(),
                //Versao = 1,
                Valor = 452.17m,
                IdConta = 1
            }
            );
        }
    }
}
