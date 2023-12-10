
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Veiculos
{
    internal class Estoque
    {
        private static List<Veiculo> _listaVeiculos = new List<Veiculo>;

        internal void AdicionarVeiculo(int assentos, int portas, decimal precoDiria, string modelo, string placa,
    TipoVeiculos veiculos)
        {
            var veiculo = new Veiculo(_listaVeiculos.Count, assentos, portas, precoDiria, modelo, placa, veiculos);
            _listaVeiculos.Add(veiculo);
        }

        internal void ExcluirVeiculo(int id)
        {
            _listaVeiculos.RemoveAll(veiculo => veiculo.Id == id);
        }

        internal Veiculo SelecionarVeiculo (int id)
        {
            return _listaVeiculos[id];
        }
    }
}
