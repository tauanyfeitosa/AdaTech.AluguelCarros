
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios
{
    internal class AcervoClientes
    {
        private static List<Cliente>? _clientes;

        internal static void AdicionarCliente (Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        internal static Cliente SelecionarCliente (string cpf)
        {
            var clienteSelecionado = _clientes.FirstOrDefault(cliente => cliente.Cpf == cpf);
            return clienteSelecionado;
        }
    }
}
