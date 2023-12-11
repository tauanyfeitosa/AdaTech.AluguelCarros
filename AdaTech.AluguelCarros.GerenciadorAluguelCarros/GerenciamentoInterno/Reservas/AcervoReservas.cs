namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.Reservas
{
    internal class AcervoReservas
    {
        private static List<Reserva> _listaReservas = new List<Reserva>();

        internal static void AdicionarReserva(Reserva reserva)
        {
            _listaReservas.Add(reserva);
        }

        internal static void ExcluirReserva(int id)
        {
            _listaReservas.RemoveAll(reserva => reserva.Id == id);
        }

        internal static Reserva SelecionarReserva(int id)
        {
            return _listaReservas.FirstOrDefault(reserva => reserva.Id == id);
        }


    }
}
