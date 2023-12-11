
using System;

namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios.InterfaceFuncionario
{
    internal class MenuFuncionario
    {
        internal static void ExibirMenu(Funcionario funcionario)
        {
            bool sair = false;

            do
            {
                Console.Clear(); 

                Console.WriteLine($"Bem-vindo, {funcionario.Nome}!");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Visualizar informações pessoais");
                Console.WriteLine("2. Realizar alguma tarefa específica");
                Console.WriteLine("3. Sair");

                if (int.TryParse(Console.ReadLine(), out int escolha))
                {
                    switch (escolha)
                    {
                        case 1:
                            VisualizarInformacoesPessoais(funcionario);
                            break;
                        case 2:
                            RealizarTarefaEspecifica(funcionario);
                            break;
                        case 3:
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }

                Console.WriteLine("Pressione Enter para continuar...");
                Console.ReadLine();

            } while (!sair);
        }

        private static void VisualizarInformacoesPessoais(Funcionario funcionario)
        {
            Console.WriteLine($"Nome: {funcionario.Nome}");
            Console.WriteLine($"CPF: {funcionario.LoginCPF}");
        }

        private static void RealizarTarefaEspecifica(Funcionario funcionario)
        {
            Console.WriteLine("Executando tarefa específica para o funcionário...");
        }
    }
}

