
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Veiculos
{
    internal class EstoqueVeiculos
    {
        private static List<Veiculo> _listaVeiculos = new List<Veiculo> ();

        internal static void AdicionarVeiculo(int assentos, int portas, decimal precoDiria, string modelo, string placa,
    TipoVeiculos veiculos)
        {
            var veiculo = new Veiculo(_listaVeiculos.Count, assentos, portas, precoDiria, modelo, placa, veiculos);
            _listaVeiculos.Add(veiculo);
        }

        internal static void ExcluirVeiculo(int id)
        {
            _listaVeiculos.RemoveAll(veiculo => veiculo.Id == id);
        }

        internal static Veiculo SelecionarVeiculo (int id)
        {
            return _listaVeiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        }
    }
}
