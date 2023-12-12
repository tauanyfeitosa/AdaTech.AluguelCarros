using AdaTech.AluguelCarros.GerenciadorAluguelCarros.Veiculos;

namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios.InterfaceFuncionario
{
    using AcoesUsuarios;
    using ConsoleMenuLibrary;
    using GerenciamentoInterno.Reservas;

    internal class MenuFuncionario
    {
        internal static void ExibirMenu(Funcionario funcionario)
        {
            bool sair = false;

            do
            {
                Console.Clear();

                string[] opcoesUsuario = { "1. Visualizar informações pessoais", "2. Realizar alguma tarefa específica", "3. Sair" };
                Console.WriteLine($"Bem-vindo, {funcionario.Nome}!\n");
                var opcoes = new ConsoleMenu(opcoesUsuario);
                int selecaoUsuario = opcoes.ShowMenu();
                switch (selecaoUsuario)
                {
                    case 0:
                        VisualizarInformacoesPessoais(funcionario);
                        break;
                    case 1:
                        MenuTarefasFuncionario.MenuTarefasEspecificas(funcionario);
                        break;
                    case 2:
                        sair = true;
                        break;
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
    }
}
