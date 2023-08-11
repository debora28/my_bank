using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLastApi.Models;
using MyLastApi.CustomValidations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyLastApi.Model
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Nas propriedades que não precisam de tabela no banco, coloca-se a anotação [NotMapped]
        public string? Nome { get; set; } = string.Empty;
        [Key, MaxLength(11), MinLength(11), CpfValidation]
        public string? Cpf { get; set; } = string.Empty;
        [Required]
        public DateTime DataNasc { get; set; }
        //public ICollection<Conta>? Contas { get; set; }

        public Usuario(string nome, string cpf, DateTime dataNasc)
        {
            Cpf = cpf;
            Nome = nome;
            DataNasc = dataNasc;
        }
    }
}
