using DesafioFundamentos.Tools;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // pede ao usuário pela placa a ser registrada
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            // verifica se placa inserida já está presente no estacionamento
            if (veiculos.Any(x => x.Equals(placa))) 
            {
                Console.WriteLine($"O veículo de placa {placa} já está presente no estacionamento");
            }

            // cria ferramenta para validar formato da placa inserida
            else
            {
                ValidadorDePlaca validador = new ValidadorDePlaca();
                if (validador.Valida(placa))
                {
                    veiculos.Add(placa);
                    Console.WriteLine($"Veículo de placa {placa} inserido com sucesso!");
                }
                else
                {
                    Console.WriteLine($"A placa inserida {placa} possui formato inválido");
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");            

                string horasString = Console.ReadLine();
                int horas;
                int.TryParse(horasString, out horas);
                decimal valorTotal = (horas * precoPorHora) + precoInicial;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine($"{veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
