
namespace Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.nomeBanco = "DigiBank";
            this.codigoBanco = "027";

        }

        public string nomeBanco { get; private set; }
        public string codigoBanco { get; private set; }
    }
    
}