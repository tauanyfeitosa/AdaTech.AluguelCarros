namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.Pagamentos
{
    using Reservas;
    internal class PagamentoCliente
    {
        private readonly decimal _valorPago;
        private readonly decimal _valorDevido;
        private DateTime _dataPagamento;
        private StatusPagamentoEnum _statusPagamento;
        private TipoPagamentoEnum _tipoPagamento;
        private decimal _saldoCliente;

        public StatusPagamentoEnum StatusPagamento { get { return _statusPagamento; } }

        internal PagamentoCliente(Reserva reserva, TipoPagamentoEnum tipoPagamento)
        {
            _valorDevido = reserva.Veiculo.CalcularAluguel(reserva.Dias);
            _statusPagamento = StatusPagamentoEnum.EmAberto;
            _tipoPagamento = tipoPagamento;
        }

        internal void EfetuarPagamento(decimal valorPago)
        {
            if (valorPago >= _valorDevido)
            {
                _dataPagamento = DateTime.Now;
                _statusPagamento = StatusPagamentoEnum.Pago;
                _saldoCliente = valorPago - _valorDevido;
            }
        }
    }
}
