
using Classes;

namespace Contratos
{

public interface IConta
{
    void deposita(double valor);
    bool saca(double valor);
    double consultaSaldo();
    string buscarCodigoBanco();
    string buscarNumeroAgencia();
    string buscarNumeroConta();
    List<Extrato> extrato();
    

}

}
