
using AdaTech.AluguelCarros.GerenciadorAluguelCarros.Veiculos;

namespace AdaTech.AluguelCarros.GerenciadorAluguelCarros.Usuarios.AcoesUsuarios
{
    internal class AcoesFuncionario
    {
        internal static void CadastrarVeiculo(Funcionario funcionario)
        {
            var informacoesUsuario = InformacoesVeiculo();

            if (informacoesUsuario.Length == 6)
            {
                if (int.TryParse(informacoesUsuario[5], out int tipoVeiculoInt) && Enum.IsDefined(typeof(TipoVeiculosEnum), tipoVeiculoInt))
                {
                    TipoVeiculosEnum tipoVeiculo = (TipoVeiculosEnum)tipoVeiculoInt;

                    try
                    {
                        funcionario.CadastrarVeiculo(
                            int.Parse(informacoesUsuario[0]),
                            int.Parse(informacoesUsuario[1]),
                            decimal.Parse(informacoesUsuario[2]),
                            informacoesUsuario[3],
                            informacoesUsuario[4],
                            tipoVeiculo
                        );

                        Console.WriteLine("Veículo cadastrado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao cadastrar veículo: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Tipo de veículo inválido.");
                }
            }
            else
            {
                Console.WriteLine("Número inválido de informações fornecidas.");
            }
        }


        private static string[] InformacoesVeiculo()
        {
            Console.WriteLine("Informe os dados do veículo separados por vírgula:");
            Console.WriteLine("Número de assentos, número de portas, preço da diária, modelo do carro, " +
                "placa do carro, tipo de veículo");
            Console.WriteLine("Escolha o tipo de veículo com base na tabela abaixo:");

            foreach (TipoVeiculosEnum tipoVeiculo in Enum.GetValues(typeof(TipoVeiculosEnum)))
            {
                Console.WriteLine($"{(int)tipoVeiculo}. {tipoVeiculo}");
            }

            var informacoesUsuario = Console.ReadLine().Split(",");
            return informacoesUsuario;
        }

        internal static int SelecionarVeiculo()
        {
            EstoqueVeiculos.ImprimirVeiculos();

            int escolhaId;
            do
            {
                Console.WriteLine("Informe qual o id do veículo:");
            } while (!int.TryParse(Console.ReadLine(), out escolhaId) || escolhaId < 0 || escolhaId >= EstoqueVeiculos.ListaVeiculos.Count);

            return escolhaId;
        }
    }
}
