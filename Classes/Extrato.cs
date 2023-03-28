

namespace Classes
{
    public class Extrato
    {
        public Extrato(DateTime data, string descricao, double valor)
        {
            this.data = data;
            this.descricao = descricao;
            this.valor = valor;

        }

        public string descricao { get; set; }
        public double valor { get; private set; }
        public DateTime data { get; private set;}

        
    }
}