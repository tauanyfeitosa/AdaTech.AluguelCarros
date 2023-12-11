using AdaTech.AluguelCarros.GerenciadorAluguelCarros.Veiculos;

namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios.InterfaceFuncionario
{
    using AcoesUsuarios;
    using AdaTech.AluguelCarros.GerenciadorAluguelCarros.GerenciamentoInterno.Reservas;

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
            bool sair = false;

            do
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
                            AcoesFuncionario.CadastrarVeiculo(funcionario);
                            break;
                        case 2:
                            int idVeiculo = AcoesFuncionario.SelecionarVeiculo();
                            var pagamentoRealizado = funcionario.VerificarPagamentoCliente(idVeiculo);
                            break;
                        case 3:
                            idVeiculo = AcoesFuncionario.SelecionarVeiculo();
                            if (AcervoReservas.SelecionarReserva(idVeiculo) != null && AcervoReservas.SelecionarReserva(idVeiculo).PagamentoCliente.StatusPagamento == 
                                GerenciamentoInterno.Pagamentos.StatusPagamentoEnum.Pago)
                            {
                                funcionario.AutorizarRetirada(idVeiculo);
                            }
                            break;
                        case 4:
                            idVeiculo = AcoesFuncionario.SelecionarVeiculo();
                            if (AcervoReservas.SelecionarReserva(idVeiculo) != null && AcervoReservas.SelecionarReserva(idVeiculo).PagamentoCliente.StatusPagamento ==
                                GerenciamentoInterno.Pagamentos.StatusPagamentoEnum.Pago)
                            {
                                funcionario.EfetivarRetirada(idVeiculo);
                            }
                            break;
                        case 5:
                            idVeiculo = AcoesFuncionario.SelecionarVeiculo();
                            if (AcervoReservas.SelecionarReserva(idVeiculo) != null && AcervoReservas.SelecionarReserva(idVeiculo).PagamentoCliente.StatusPagamento ==
                                GerenciamentoInterno.Pagamentos.StatusPagamentoEnum.Pago)
                            {
                                EstoqueVeiculos.ExcluirVeiculo(idVeiculo);
                            }
                            break;
                        case 6:
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
    }
}
