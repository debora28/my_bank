using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLastApi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLastApi.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        //Nas propriedades que não precisam de tabela no banco, coloca-se a anotação [NotMapped]
        [NotMapped]
        static int nextId;
        public string? Nome { get; set; }
        [Key, MaxLength(11), MinLength(11)]
        public string? Cpf { get; set; }
        [Required]
        public DateTime DataNasc { get; set; }
        //public ICollection<Operacao>? Operacoes { get; set; }

        public Usuario(string nome, string cpf, DateTime dataNasc)
        {
            Cpf = cpf;
            Nome = nome;
            DataNasc = dataNasc;
        }
        Usuario()
        {
            Id = Interlocked.Increment(ref nextId);
        }
    }
}
