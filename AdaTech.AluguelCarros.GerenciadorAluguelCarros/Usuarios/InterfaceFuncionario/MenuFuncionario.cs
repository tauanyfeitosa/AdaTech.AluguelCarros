
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
                            MenuTarefasEspecificas(funcionario);
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

        private static void MenuTarefasEspecificas(Funcionario funcionario)
        {
            Console.WriteLine("\n\nEscolha uma opção de suas tarefas específicas:");
            Console.WriteLine("1. Cadastrar Veículo");
            Console.WriteLine("2. Verificar o pagamento do cliente.");
            Console.WriteLine("3. Autorizar retirada do veiculo.");
            Console.WriteLine("4. Retirar veículo (mesmo fora do prazo)");
            Console.WriteLine("5. Excluir veículo.");
            Console.WriteLine("6. Sair.");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                switch (escolha)
                {
                    case 1:
                        funcionario.CadastrarVeiculo()
                        break;
                    case 2:
                        break;
                    case 3:
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
        }

        private static string[] InformacoesVeiculo()
        {
            Console.WriteLine("Informe os dados do veículo separados por vírgula:");
            Console.WriteLine("Número de assentos, número de portas, preço da diária, modleo do carro, placa do carro, tipo de veículo");

        }  
    }
}

