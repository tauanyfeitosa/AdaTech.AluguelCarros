
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros
{
    using Veiculos;
    using GerenciamentoInterno;
    internal class Cliente
    {
        private readonly string? _id;
        private readonly string? _cpf;
        private readonly string? _nome;
        private readonly string? _cnh;
        private int _idade;
        private bool _possuiCNH;

        internal string? Id { get { return _id; } }

        internal string? Cpf { get { return _cpf; } }

        internal string? Nome { get { return _nome; }
        }
        internal string? Cnh { get { return _cnh; } }

        internal int Idade
        {
            get { return _idade; }
            set { _idade = value; }
        }

        internal bool PossuiCNH
        {
            get { return _possuiCNH; }
            set { _possuiCNH = value; }
        }

        internal void FazerReserva (int idVeiculo, DateTime dataInicio, DateTime dataFim)
        {
            Veiculo veiculo = EstoqueVeiculos.SelecionarVeiculo(idVeiculo);
            var reservaCliente = new Reserva(idVeiculo, veiculo, this, dataInicio, dataFim);

            EstoqueReservas.AdicionarReserva(reservaCliente);
        }
    }
}
