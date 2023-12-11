
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Veiculos
{
    internal class Veiculo
    {
        private readonly int _id;
        private bool _revisaoAtualizada;
        private StatusCarroEnum _statusCarro;
        private int _assentos;
        private int _portas;
        private decimal _precoDiaria;
        private string? _modelo;
        private string? _placa;
        private TipoVeiculosEnum _veiculos;

        internal int Id
        {
            get { return _id; }
        }

        internal bool RevisaoAtualizada
        {
            get { return _revisaoAtualizada; }
            set { _revisaoAtualizada = value; }
        }

        internal StatusCarroEnum StatusCarro
        {
            get { return _statusCarro; }
            set { _statusCarro = value; }
        }

        internal int Assentos
        {
            get { return _assentos; }
            set { _assentos = value; }
        }

        internal int Portas
        {
            get { return _portas; }
            set { _portas = value; }
        }

        internal decimal PrecoDiaria
        {
            get { return _precoDiaria; }
            set { _precoDiaria = value; }
        }

        internal string? Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        internal string? Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }

        internal TipoVeiculosEnum Veiculos
        {
            get { return _veiculos; }
            set { _veiculos = value; }
        }

        public Veiculo(int id, int assentos, int portas, decimal precoDiria, string modelo, string placa, 
            TipoVeiculosEnum veiculos)
        {
            this._id = id;
            this._assentos = assentos;
            this._portas = portas;
            this._precoDiaria = precoDiria;
            this._modelo = modelo;
            this._placa = placa;
            this._veiculos = veiculos;
            this._revisaoAtualizada = true;
            this._statusCarro = StatusCarroEnum.Disponivel;
        }

        internal decimal CalcularAluguel (int dias)
        {
            return dias * _precoDiaria;
        }

    }
}
