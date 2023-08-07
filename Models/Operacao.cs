using MyLastApi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLastApi.Models
{
    public class Operacao
    {
        [Key]
        public int IdOperacao { get; set; }
        [NotMapped]
        static int nextId;
        [Required]
        public string ? TipoOperacao { get; set; }
        public DateTime DataOperacao { get; set; }
        [Timestamp]
        public byte[] ? Versao { get; set; }
        [Required]
        public decimal ? Valor { get; set; }

        Operacao()
        {
            IdOperacao = Interlocked.Increment(ref nextId);
        }
    }
}
