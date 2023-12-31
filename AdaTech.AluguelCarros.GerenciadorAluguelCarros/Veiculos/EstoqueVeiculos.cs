﻿
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Veiculos
{
    internal class EstoqueVeiculos
    {
        private static List<Veiculo> _listaVeiculos = new List<Veiculo> ();

        public static List<Veiculo> ListaVeiculos => _listaVeiculos;

        internal static void AdicionarVeiculo(int assentos, int portas, decimal precoDiria, string modelo, string placa,
    TipoVeiculosEnum veiculos)
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

        internal static void ImprimirVeiculos()
        {
            Console.WriteLine("Lista de Veículos:");

            foreach (var veiculo in _listaVeiculos)
            {
                Console.WriteLine($"ID: {veiculo.Id}, Modelo: {veiculo.Modelo}, Placa: {veiculo.Placa}");
            }
        }
    }
}
