
using AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios;

namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros
{
    using Usuarios.InterfaceFuncionario;
    class Program
    {
        public static void Main ()
        {
            while (true)
            {
                Console.WriteLine("Informe abaixo qual o seu vínculo: \n1 - Funcionário\n2- Cliente");
                if (int.TryParse(Console.ReadLine(), out int selecaoUsuario))
                {
                    switch (selecaoUsuario)
                    {
                        case 1:
                            var funcionario = InterfaceFuncionarioLogin.AdicionarFuncionario();
                            MenuFuncionario.ExibirMenu(funcionario);
                            break;
                        case 2:
                            break;
                        default: Console.WriteLine("Selecao Inválida!"); break;
                    }
                }
            }
        }

    }
}
