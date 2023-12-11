
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios
{
    using GerenciamentoInterno.Reservas;
    using GerenciamentoInterno.Pagamentos;
    using GerenciamentoInterno.RetiradasDevolucoes;
    using Veiculos;
    internal class Funcionario
    {
        private readonly string? _nome;
        private readonly int _id;
        private readonly string? _loginCPF;
        private string? _senha;
        private bool _ativo;

        public Funcionario(string nome, string loginCPF, string senha, string confirmacaoSenha)
        {
            if (senha != confirmacaoSenha)
            {
                throw new ArgumentException("As senhas não correspondem!");
            }

            this._nome = nome;
            this._loginCPF = loginCPF;
            this._senha = senha;
        }

        internal void CadastrarVeiculo(int assentos, int portas, decimal precoDiria, string modelo, string placa,
            TipoVeiculos veiculos)
        {
            EstoqueVeiculos.AdicionarVeiculo(assentos, portas, precoDiria, modelo, placa, veiculos);

        }

        internal bool VerificarPagamentoCliente (int id)
        {
            var reserva = AcervoReservas.SelecionarReserva(id);
            if (reserva.PagamentoCliente.StatusPagamento == StatusPagamento.Pago)
            {
                return true;
            }
            return false;
        }

        internal void AutorizarRetirada (int id)
        {
            var reserva = AcervoReservas.SelecionarReserva(id);
            if (VerificarPagamentoCliente(id))
            {
                var retiradaVeiculo = new RetiradaVeiculo(reserva);
            }
        }
    }
}
