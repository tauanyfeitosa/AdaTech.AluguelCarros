
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.RetiradasDevolucoes
{
    using Reservas;
    internal class RetiradaVeiculo
    {
        private bool _veiculoRetirado;

        public bool VeiculoRetirado { get { return _veiculoRetirado; } }

        internal RetiradaVeiculo (Reserva reserva)
        {
            if (reserva.DataInicio == DateTime.Now)
            {
                _veiculoRetirado = true;
            }
            else
            {
                _veiculoRetirado = false;
            }

        }
        internal void RetirarVeiculoDia (Reserva reserva)
        {
            this._veiculoRetirado = true;
            reserva.DataInicio = DateTime.Now;
            reserva.Veiculo.StatusCarro = Veiculos.StatusCarroEnum.Indisponivel;
        }
    }
}
