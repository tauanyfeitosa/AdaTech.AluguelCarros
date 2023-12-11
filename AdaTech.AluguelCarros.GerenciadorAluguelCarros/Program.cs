
using AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios;

namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros
{
    class Program
    {
        public static void Main ()
        {
            while (true)
            {
                Console.WriteLine("Informe abaixo qual o seu vínculo: 1 - Funcionário\n2- Cliente");
                if (int.TryParse(Console.ReadLine(), out int selecaoUsuario))
                {
                    switch (selecaoUsuario)
                    {
                        case 1:
                            AdicionarFuncionario();
                            break;
                        case 2:
                            break;
                        default: Console.WriteLine("Selecao Inválida!"); break;
                    }
                }
            }
        }

        private static Funcionario AdicionarFuncionario()
        {
            Console.WriteLine("Informe o CPF do funcionário:");
            var cpfFuncionario = Console.ReadLine();


            var funcionarioExistente = AcervoFuncionario.SelecionarFuncionario(cpfFuncionario);

            if (funcionarioExistente != null)
            {
                Console.WriteLine("Funcionário já existe na lista.");
                var funcionario = funcionarioExistente;
            }
            else
            {
                Console.WriteLine("O funcionário não foi encontrado em nosso sistema, faremos o " +
                    "cadastro do mesmo. Informe os dados abaixo:");

                Console.WriteLine("Informe o nome do funcionário:");
                var nomeFuncionario = Console.ReadLine();

                Console.WriteLine("Informe a senha do usuario");
                var senha = Console.ReadLine();

                Console.WriteLine("Confirme a sua senha!");
                var confimacaoSenha = Console.ReadLine();

                try
                {
                    funcionarioExistente = new Funcionario(nomeFuncionario, cpfFuncionario, senha, confimacaoSenha);

                    AcervoFuncionario.AdicionarFuncionario(funcionarioExistente);
                    Console.WriteLine("Funcionário adicionado com sucesso!");
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                } 
            }
            return funcionarioExistente;
        }
    }
}
