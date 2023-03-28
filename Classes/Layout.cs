using Classes;

namespace Digibank.Classes
{

public class Layout
{
    private static List<Pessoa> pessoas = new List<Pessoa>();
    private static int opcao = 0;
    public static void telaPrincipal()
    {
       
       Console.WriteLine("                                      ");
       Console.WriteLine("     Digite a opção desejada :        ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     1 - Criar Conta                  ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     2 - Entrar com CPF e senha       ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("                                      ");
       
       opcao = int.Parse(Console.ReadLine());

       switch (opcao)
       {
          case 1:
            telaCriar();
            break;
          case 2:
            telaLogin();
            break;
          default:
            Console.WriteLine("Opção inválida!");
            break;  
       }


    }

    private static void telaCriar()
    {
        Console.Clear();

       Console.WriteLine("                                      ");
       Console.WriteLine("     Digite seu nome :                ");
       string nome = Console.ReadLine();
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     Digite o CPF :                   ");
       string cpf = Console.ReadLine();
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     Digite sua senha :               ");
       string senha = Console.ReadLine();
       Console.WriteLine("     =============================    ");
       Console.WriteLine("                                      ");
       
       ContaCorrente contaCorrente = new ContaCorrente();
       Pessoa pessoa = new Pessoa();

       pessoa.setNome(nome);
       pessoa.setCPF(cpf);
       pessoa.setSenha(senha);
       pessoa.Conta = contaCorrente;
       pessoas.Add(pessoa);

       Console.Clear();

       Console.WriteLine("     Conta cadastrada com sucesso!    ");
       Console.WriteLine("     =============================    ");

       Thread.Sleep(2000);

       telaLogado(pessoa);

       
    }

    private static void telaLogin()
    {

       Console.Clear();

       Console.WriteLine("                                      ");
       Console.WriteLine("     Digite o CPF :                   ");
       string cpf = Console.ReadLine();
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     Digite sua senha:                ");
       string senha = Console.ReadLine();
       Console.WriteLine("     =============================    ");
       Console.WriteLine("                                      ");
       
       Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.senha == senha);

       if(pessoa != null)
       {
          telaBoasVindas(pessoa);

          telaLogado(pessoa);


       }else
       {
        Console.Clear();

        Console.WriteLine("     Pessoa não cadastrada!           ");
        Console.WriteLine("     =============================    ");
        Console.WriteLine("                                      ");
        Console.WriteLine("                                      ");


       }
    }

    private static void telaBoasVindas(Pessoa pessoa)
    {
        string msgTelaBoasVindas =
        $"{pessoa.nome} - Banco: {pessoa.Conta.buscarCodigoBanco()}" +
        $"- Agencia: {pessoa.Conta.buscarNumeroAgencia()} - Conta: {pessoa.Conta.buscarNumeroConta()}";
        Console.WriteLine("                                            ");
        Console.WriteLine($"  Seja bem vindo(a), {msgTelaBoasVindas}   ");
        Console.WriteLine("                                            ");
      
    }
    
    private static void telaLogado(Pessoa pessoa)
    {
        Console.Clear();

        telaBoasVindas(pessoa);

       Console.WriteLine("                                      ");
       Console.WriteLine("     Digite a opção desejada :        ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     1 - Realizar um Deposito         ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     2 - Realizar um saque            ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     3 - Consultar Saldo              ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     4 - Extrato                      ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     5 - Sair                         ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("                                      ");

       opcao = int.Parse(Console.ReadLine());

       switch (opcao)
        {
          case 1:
            telaDeposito(pessoa);
            break;
          case 2:
            telaSaque(pessoa);
            break;
          case 3:
            telaSaldo(pessoa);
            break;
          case 4:
            telaExtrato(pessoa);
            break;
          case 5:
            telaPrincipal();
            break;
          default:
             Console.Clear();
             Console.WriteLine("                                      ");
             Console.WriteLine("     Opção Inválida!                  ");
             Console.WriteLine("     =============================    ");
             Console.WriteLine("                                      ");
            break;  
        }
    } 

    
    private static void telaDeposito(Pessoa pessoa)
    {
      Console.Clear();

       telaBoasVindas(pessoa);

       Console.WriteLine("     Digite o valor do deposito:      ");
       double valor = double.Parse(Console.ReadLine());
       Console.WriteLine("     =============================    ");

       pessoa.Conta.deposita(valor);

       Console.Clear();

       telaBoasVindas(pessoa);

       Console.WriteLine("                                      ");
       Console.WriteLine("     Deposito Realizado com Sucesso!  ");
       Console.WriteLine("     ===============================  ");
       Console.WriteLine("                                      ");

       opcaoVoltarLogado(pessoa);

    }

    private static void opcaoVoltarLogado(Pessoa pessoa)
    {
       Console.WriteLine("                                      ");
       Console.WriteLine("     Entre com uma opção abaixo:      ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     1 - Voltar para minha conta      ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("     2 - Sair                         ");
       Console.WriteLine("     =============================    ");
       Console.WriteLine("                                      ");

       opcao = int.Parse(Console.ReadLine());

       if(opcao == 1)
         telaLogado(pessoa);
       else
         telaPrincipal();
    }

    private static void opcaoVoltarDeslogado()
    {
       Console.WriteLine("                                           ");
       Console.WriteLine("     Entre com uma opção abaixo:           ");
       Console.WriteLine("     ================================      ");
       Console.WriteLine("     1 - Voltar para o menu principal      ");
       Console.WriteLine("     ================================      ");
       Console.WriteLine("     2 - Sair                              ");
       Console.WriteLine("     ================================      ");
       Console.WriteLine("                                           ");

       opcao = int.Parse(Console.ReadLine());

       if(opcao == 1)
         telaPrincipal();
       else
         {
          Console.WriteLine("     Opção Inválida!                     ");
          Console.WriteLine("     ================================    ");
         }
    }

    private static void telaSaque(Pessoa pessoa)
    {
      Console.Clear();

      telaBoasVindas(pessoa);

       Console.WriteLine("     Digite o valor do saque:         ");
       double valor = double.Parse(Console.ReadLine());
       Console.WriteLine("     =============================    ");

       bool okSaque = pessoa.Conta.saca(valor);

       Console.Clear();

       telaBoasVindas(pessoa);

       Console.WriteLine("                                      ");
       if(okSaque)
       {
       Console.WriteLine("     Saque Realizado com Sucesso!     ");
       Console.WriteLine("     ===============================  ");
       }
       else
       {
       Console.WriteLine("     Saldo insuficiente!              ");
       Console.WriteLine("     ===============================  ");
       }

       Console.WriteLine("                                      ");

       opcaoVoltarLogado(pessoa);

    }

    private static void telaSaldo(Pessoa pessoa)
    {
      Console.Clear();

      telaBoasVindas(pessoa);

      Console.WriteLine($"     Seu saldo é: {pessoa.Conta.consultaSaldo()}  ");
      Console.WriteLine("     ============================                  ");
      Console.WriteLine("                                                   ");

      opcaoVoltarLogado(pessoa);

    }

    private static void telaExtrato(Pessoa pessoa)
    {
      Console.Clear();

      telaBoasVindas(pessoa);

      if(pessoa.Conta.extrato().Any())
      {
        double total = pessoa.Conta.extrato().Sum(x => x.valor);

        foreach(Extrato extrato in pessoa.Conta.extrato())
        {
          Console.WriteLine($"      Data: {extrato.data.ToString("dd/MM/yyy HH:mm:ss")} ");
          Console.WriteLine($"      Tipo de movimentação: {extrato.descricao}           ");
          Console.WriteLine($"      Valor: {extrato.valor}                              ");
          Console.WriteLine("       ==========================================          ");

        }

        Console.WriteLine("                                      ");
        Console.WriteLine($"     SUB TOTAL: {total}              ");
        Console.WriteLine("     =============================    ");
        Console.WriteLine("                                      ");

      }
      else
      {
        Console.WriteLine("    Não há extrato a ser exibido!                ");
        Console.WriteLine("    =============================                ");
      }

      opcaoVoltarLogado(pessoa);

    }


}

}