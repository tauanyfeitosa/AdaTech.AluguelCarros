
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios
{
    internal class AcervoFuncionario
    {
        private static List<Funcionario>? _funcionario = new List<Funcionario>();

        public List<Funcionario> Funcionario => _funcionario ?? new List<Funcionario>();

        internal static void AdicionarFuncionario(Funcionario funcionario)
        {
            _funcionario.Add(funcionario);
        }

        internal static Funcionario? SelecionarFuncionario(string cpf)
        {
            var funcionarioSelecionado = _funcionario?.FirstOrDefault(funcionario => funcionario.LoginCPF == cpf);
            return funcionarioSelecionado;
        }
    }
}
