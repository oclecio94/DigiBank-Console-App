using Contratos;


namespace Classes
{
    public class Pessoa
    {
        public string nome { get; private set; }
        public string CPF { get; private set; }
        public string senha { get; private set; }
        public IConta Conta { get; set; }

    

        public void setNome(string nome)
        {
         this.nome = nome;
        }
        public void setCPF(string CPF)
        {
         this.CPF = CPF;
        }
        public void setSenha(string senha)
        {
         this.senha = senha;
        }

    }
}