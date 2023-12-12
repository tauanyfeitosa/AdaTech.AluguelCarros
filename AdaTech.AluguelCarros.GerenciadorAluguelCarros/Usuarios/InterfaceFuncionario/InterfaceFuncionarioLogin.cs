
using AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios.AcervoUsuarios;

namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios.InterfaceFuncionario
{
    internal class InterfaceFuncionarioLogin
    {
        internal static (Funcionario funcionario, int resultado) AdicionarFuncionario()
        {
            Console.WriteLine("Informe o CPF do funcionário:");
            var cpfFuncionario = Console.ReadLine().Replace(".", "").Replace("-", "");

            var funcionarioExistente = AcervoFuncionario.SelecionarFuncionario(cpfFuncionario);

            if (funcionarioExistente != null)
            {
                Console.WriteLine("Funcionário já existe na lista.");
                return (funcionarioExistente, 0);
            }

            Console.WriteLine("O funcionário não foi encontrado em nosso sistema, faremos o " +
                "cadastro do mesmo. Informe os dados abaixo:");

            var nomeFuncionario = ObterNomeFuncionario();
            var senha = ObterSenha();
            var confirmacaoSenha = ConfirmarSenha();

            try
            {
                var novoFuncionario = new Funcionario(nomeFuncionario, cpfFuncionario, senha, confirmacaoSenha);

                AcervoFuncionario.AdicionarFuncionario(novoFuncionario);
                Console.WriteLine("Funcionário adicionado com sucesso!");
                return (novoFuncionario, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return (null, 2);
            }
        }

        internal static (Funcionario funcionario, int resultado) LoginFuncionario (Funcionario funcionario) 
        {
            var senhaAcesso = ObterSenha();
            if (senhaAcesso != funcionario.Senha)
            {
                return (funcionario, -1);
            } else
            {
                return (funcionario, 3);
            }
        }

        private static string ObterNomeFuncionario()
        {
            Console.WriteLine("Informe o nome do funcionário:");
            return Console.ReadLine();
        }

        private static string ObterSenha()
        {
            Console.WriteLine("Informe a senha do usuário:");
            return Console.ReadLine();
        }

        private static string ConfirmarSenha()
        {
            Console.WriteLine("Confirme a sua senha:");
            return Console.ReadLine();
        }

    }
}
