
namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios.InterfaceFuncionario
{
    using ConsoleMenuLibrary;
    using GerenciamentoInterno.Reservas;
    using Usuarios.AcoesUsuarios;
    using Veiculos;

    internal class MenuTarefasFuncionario
    {
        internal static void MenuTarefasEspecificas(Funcionario funcionario)
        {
            bool sair = false;

            do
            {
                string[] tarefasEspecificasMenu = { "1. Cadastrar Veículo",
                    "2. Verificar o pagamento do cliente",
                    "3. Autorizar retirada do veiculo",
                    "4. Retirar veículo (mesmo fora do prazo)",
                    "5. Excluir veículo",
                    "6. Sair"
                };
                Console.WriteLine("\n\nEscolha uma opção de suas tarefas específicas:");

                var opcoesUsuario = new ConsoleMenu(tarefasEspecificasMenu);

                int selecaoUsuario = opcoesUsuario.ShowMenu();

                sair = RetornarAcaoFuncionario(selecaoUsuario, funcionario);

            } while (!sair);
        }

        private static bool RetornarAcaoFuncionario (int escolha, Funcionario funcionario)
        {
            bool sair = false;
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

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
            return sair;
        }
    }
}
