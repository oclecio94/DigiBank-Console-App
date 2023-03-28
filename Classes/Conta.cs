
using Classes;
using Contratos;

namespace Classes
{
    public abstract class Conta : Banco, IConta
    {
        public Conta()
        {
            this.numeroAgencia = "0001";
            Conta.numeroContaSequencial++;
            this.movimentacoes = new List<Extrato>();
            

        }

        public double saldo { get; protected set; }
        public string numeroAgencia { get; private set; }
        public string numeroConta { get; protected set; }

        public static int numeroContaSequencial { get; private set; }

        private List<Extrato> movimentacoes;
        public string buscarCodigoBanco()
        {
            return this.codigoBanco;
        }

        public string buscarNumeroAgencia()
        {
            return this.numeroAgencia;
        }

        public string buscarNumeroConta()
        {
            return this.numeroConta;
        }

        public double consultaSaldo()
        {
            return this.saldo;
        }

        public void deposita(double valor)
        {
            DateTime dataAtual = DateTime.Now;
            this.movimentacoes.Add(new Extrato(dataAtual, "Deposito", valor));
            this.saldo += valor;
        }

        public bool saca(double valor)
        {
            if (valor > consultaSaldo())
            return false;

            DateTime dataAtual = DateTime.Now;
            this.movimentacoes.Add(new Extrato(dataAtual, "Saque", -valor));

            this.saldo -= valor;
            return true;


        }

        public List<Extrato> extrato()
        {
            return this.movimentacoes;
        }
    }
}