
using AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios;

namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros
{
    using Usuarios.InterfaceFuncionario;
    using ConsoleMenuLibrary;
    class Program
    {
        public static void Main ()
        {
            while (true)
            {
                Console.WriteLine("Informe abaixo qual o seu vínculo:");
                string[] opcoesUsuario = { "1. Funcionário", "2. Cliente" };
                var menuPrincipal = new ConsoleMenu(opcoesUsuario);
                int selecaoUsuario = menuPrincipal.ShowMenu();
                switch (selecaoUsuario)
                {
                    case 0:
                        var funcionarioTupla = InterfaceFuncionarioLogin.AdicionarFuncionario();
                        if (funcionarioTupla.resultado == 0)
                        {
                            var funcionarioCadastradoTupla = InterfaceFuncionarioLogin.LoginFuncionario(funcionarioTupla.funcionario);
                            if (funcionarioCadastradoTupla.resultado == -1)
                            {
                                Console.WriteLine("Senha incorreta\n");
                                Thread.Sleep(1000);
                                Console.WriteLine("Você será redirecionado ao menu principal (Funcionário x Cliente)!");
                                Thread.Sleep(2000);
                                continue;
                            }
                        }
                        MenuFuncionario.ExibirMenu(funcionarioTupla.funcionario);
                        break;
                    case 1:
                        break;
                    default: Console.WriteLine("Selecao Inválida!"); break;
                }
            }
        }

    }
}
