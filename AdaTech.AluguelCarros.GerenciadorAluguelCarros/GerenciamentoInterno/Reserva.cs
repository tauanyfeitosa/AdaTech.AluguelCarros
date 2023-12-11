
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno
{
    using Veiculos;

    internal class Reserva
    {
        private readonly int _id;
        private readonly Veiculo? _veiculo;
        private readonly Cliente? _ciente;
        private int _dias;
        private readonly DateTime _dataInicio;
        private DateTime _dataFim;
        private decimal _valorTotal;
        private bool reservaAutorizada = false;

        public int Id { get { return _id; } }

        private void CalcularDias ()
        {
            this._dias = (this._dataFim - this._dataInicio).Days;

        }
        internal void AtualizarValorTotal ()
        {
            CalcularDias ();
            this._valorTotal = this._dias * this._veiculo.PrecoDiaria;
        }

        public Reserva(int id, Veiculo veiculo, Cliente cliente, DateTime dataInicio, DateTime dataFim)
        {
            this._id = id;
            this._veiculo = veiculo;
            this._ciente = cliente;
            this._dataInicio = dataInicio;
            this._dataFim = dataFim;

            AtualizarValorTotal ();
        }

    }
}
