namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.Pagamentos
{
    using Reservas;
    internal class PagamentoCliente
    {
        private readonly decimal _valorPago;
        private readonly decimal _valorDevido;
        private DateTime _dataPagamento;
        private StatusPagamento _statusPagamento;
        private TipoPagamento _tipoPagamento;
        private decimal _saldoCliente;

        public StatusPagamento StatusPagamento { get { return _statusPagamento; } }

        internal PagamentoCliente(Reserva reserva, TipoPagamento tipoPagamento)
        {
            _valorDevido = reserva.Veiculo.CalcularAluguel(reserva.Dias);
            _statusPagamento = StatusPagamento.EmAberto;
            _tipoPagamento = tipoPagamento;
        }

        internal void EfetuarPagamento(decimal valorPago)
        {
            if (valorPago >= _valorDevido)
            {
                _dataPagamento = DateTime.Now;
                _statusPagamento = StatusPagamento.Pago;
                _saldoCliente = valorPago - _valorDevido;
            }
        }
    }
}
