using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyLastApi.Model;

namespace MyLastApi.Models
{
    public class ContaBancaria
    {
        [Key]
        public int IdConta { get; }
        [NotMapped]
        static int nextId;
        [Required]
        public string Agencia { get; } = string.Empty;
        [Required]
        public string NumConta { get; } = string.Empty;
        public decimal Saldo { get; set; }
        public bool Ativa { get; set; }
        public bool Bloqueada { get; set; }
        public decimal LimiteDiario { get; set; }

        public Usuario? Cliente { get; set; }
        //public ICollection<Operacao>? Operacoes { get; set; }
   
        public ContaBancaria(Usuario cliente, string agencia, string numConta, decimal saldo, bool ativa, bool flagBloqueio, decimal limiteDiario)
        {
            this.Cliente = cliente;
            this.Agencia = agencia;
            this.NumConta = numConta;
            this.Saldo = saldo;
            this.Ativa = ativa;
            this.Bloqueada = flagBloqueio;
            this.LimiteDiario = limiteDiario;
        }
        ContaBancaria()
        {
            IdConta = Interlocked.Increment(ref nextId);
        }
        public decimal ConsultarSaldo()
        {
            return this.Saldo;
        }

        public void ExibirDadosConta()
        {
            Console.WriteLine($"Agência: {this.Agencia}\n" +
                $"Conta: {this.NumConta}\n" +
                //$"Cliente: {this.Cliente.Nome}\n" +
                $"Saldo: {this.Saldo}\n" +
                $"Limite Diário: {this.LimiteDiario}\n" +
                $"Aviso: {(this.Bloqueada == true ? "Conta Desbloqueada" : "Conta Bloqueada")}\n"
                );
        }
        //Colocar os métodos separados em "Serviços".
        public decimal Sacar(decimal valor, ContaBancaria conta)
        {
            if (conta.Ativa == true && conta.Bloqueada == false && (conta.Saldo - valor) >= 0 && valor <= conta.LimiteDiario)
            {
                this.Saldo -= valor;
            }
            else if (conta.Ativa == false)
            {
                Console.WriteLine("Operação indisponível. Esta conta está inativa.");
            }
            else if (conta.Bloqueada == true)
            {
                Console.WriteLine("Operação indisponível. Esta conta está bloqueada.");
            }
            else if ((conta.Saldo - valor) < 0)
            {
                Console.WriteLine("Saldo insuficiente.");
            }
            else if (valor > conta.LimiteDiario)
            {
                Console.WriteLine("Operação não realizada. Esse valor excede o limite diário de movimentação.");
            }
            else
            {
                Console.WriteLine("Não foi possível realizar esta operação. Por favor, entre em contato com a instituição financeira.");
            }
            return conta.Saldo;
        }

        public decimal Depositar(decimal valor, ContaBancaria conta)
        {
            if (conta.Ativa == true && conta.Bloqueada == false && valor > 0)
            {
                conta.Saldo += valor;
            }
            else if (conta.Ativa == false)
            {
                Console.WriteLine("Operação indisponível. Esta conta está inativa.");
            }
            else if (conta.Bloqueada == true)
            {
                Console.WriteLine("Operação indisponível. Esta conta está bloqueada.");
            }
            else if (valor <= 0)
            {
                Console.WriteLine("Valor insuficiente.");
            }
            else
            {
                Console.WriteLine("Não foi possível realizar esta operação. Por favor, entre em contato com a instituição financeira.");
            }
            return conta.Saldo;
        }

        public string BloquearConta(ContaBancaria conta)
        {
            conta.Bloqueada = !conta.Bloqueada;

            if (conta.Bloqueada)
            {
                return "Conta bloqueada para sua segurança.";
            }
            else
            {
                return "Conta desbloqueada e pronta para uso.";
            }
        }

        public decimal DefinirLimite(decimal limite, ContaBancaria conta)
        {
            if (limite >= 0)
            {
                conta.LimiteDiario = limite;
                return conta.LimiteDiario;
            }
            else
            {
                Console.WriteLine("Valor não permitido.");
                return conta.LimiteDiario;
            }
        }
    }
}
