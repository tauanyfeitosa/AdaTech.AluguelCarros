namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.Reservas
{
    using AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.Pagamentos;
    using AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios;
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
        private readonly PagamentoCliente? _pagamentoCliente;

        public int Id { get { return _id; } }
        public Veiculo Veiculo { get { return _veiculo; } }
        public int Dias { get { return _dias; } }
        public DateTime DataInicio { get { return _dataInicio; } }
        public PagamentoCliente PagamentoCliente { get { return _pagamentoCliente; } }

        private void CalcularDias()
        {
            _dias = (_dataFim - _dataInicio).Days;

        }
        internal void AtualizarValorTotal()
        {
            CalcularDias();
            _valorTotal = _dias * _veiculo.PrecoDiaria;
        }

        public Reserva(int id, Veiculo veiculo, Cliente cliente, DateTime dataInicio, DateTime dataFim, 
            TipoPagamento tipoPagamento)
        {
            this._id = id;
            this._veiculo = veiculo;
            this._ciente = cliente;
            this._dataInicio = dataInicio;
            this._dataFim = dataFim;
            this._pagamentoCliente = new PagamentoCliente(this, tipoPagamento);

            AtualizarValorTotal();
        }

    }
}
