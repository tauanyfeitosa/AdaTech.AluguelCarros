
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno
{
    using Veiculos;

    internal class Reserva
    {
        private readonly string? _id;
        private readonly Veiculo? _veiculo;
        private int _dias;
        private readonly  DateTime _dataInicio;
        private DateTime _dataFim;
        private decimal _valorTotal;
        private bool reservaAutorizada;

        internal void AtualizarValorTotal ()
        {
            this._dias = (this._dataFim - this._dataInicio).Days;
            this._valorTotal = this._dias * this._veiculo.PrecoDiaria;
        }

    }
}
