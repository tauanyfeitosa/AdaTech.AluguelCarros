
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.RetiradasDevolucoes
{
    using Reservas;
    internal class DevolucaoVeiculo
    {
        private readonly bool _veiculoDevolvido = false;
        public DevolucaoVeiculo(Reserva reserva)
        {
            this._veiculoDevolvido = true;
            reserva.Veiculo.StatusCarro = Veiculos.StatusCarroEnum.Disponivel;
            reserva.DataFim = DateTime.Now;
        }
    }
}
