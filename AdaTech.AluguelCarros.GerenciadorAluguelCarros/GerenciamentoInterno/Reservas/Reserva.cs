namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.Reservas
{
    using GerenciamentoInterno.Pagamentos;
    using GerenciamentoInterno.RetiradasDevolucoes;
    using Usuarios;
    using Veiculos;

    internal class Reserva
    {
        private readonly int _id;
        private readonly Veiculo? _veiculo;
        private readonly Cliente? _ciente;
        private int _dias;
        private DateTime _dataInicio;
        private DateTime _dataFim;
        private decimal _valorTotal;
        private bool reservaAutorizada = false;
        private readonly PagamentoCliente? _pagamentoCliente;
        private RetiradaVeiculo _retiradaVeiculo;
        private DevolucaoVeiculo _devolucaoVeiculo;

        public int Id { get { return _id; } }
        public Veiculo Veiculo { get { return _veiculo; } }
        public int Dias { get { return _dias; } }
        public DateTime DataInicio
        {
            get { return _dataInicio; }
            set
            {
                if (value >= DateTime.Now)
                {
                    _dataInicio = value;
                }
                else
                {
                    Console.WriteLine("A data de início não pode ser no passado.");
                }
            }
        }
        public DateTime DataFim
        {
            get { return _dataInicio; }
            set
            {
                if (value >= DateTime.Now)
                {
                    _dataInicio = value;
                }
                else
                {
                    Console.WriteLine("A data de início não pode ser no passado.");
                }
            }
        }
        public PagamentoCliente PagamentoCliente { get { return _pagamentoCliente; } }
        public RetiradaVeiculo RetiradaVeiculo { get { return _retiradaVeiculo; } }
        public DevolucaoVeiculo DevolucaoVeiculo { get { return _devolucaoVeiculo; } }

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
            TipoPagamentoEnum tipoPagamento)
        {
            this._id = id;
            this._veiculo = veiculo;
            this._ciente = cliente;
            this._dataInicio = dataInicio;
            this._dataFim = dataFim;
            this._pagamentoCliente = new PagamentoCliente(this, tipoPagamento);

            AtualizarValorTotal();
        }

        internal void CriarRetiradaVeiculo ()
        {
            this._retiradaVeiculo = new RetiradaVeiculo(this);
        }
        
        internal void CriarDevolucaoVeiculo ()
        {
            this._devolucaoVeiculo = new DevolucaoVeiculo(this);
        }

    }
}
