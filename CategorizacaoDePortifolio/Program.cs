using System;
using System.Collections.Generic;
using System.Globalization;
using CategorizacaoDePortifolio.Interface;
using CategorizacaoDePortifolio;

namespace PortfolioCategorization
{
    class Program
    {
        static void Main(string[] args)
        {                    
            Console.Write("Informe a data de referência (MM/dd/yyyy): ");
            if (!DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataDeReferencia))
            {
                Console.WriteLine("Data Inválida");
                return;
            }

            Console.Write("Informe o número de operações: ");
            int n = int.Parse(s: Console.ReadLine());
            
            List<ITrade> trades = new List<ITrade>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Informe os dados da operação {i + 1} (valor setor dataPagamento - formato: 2000000 Private 12/29/2025): ");
                string? entrada = Console.ReadLine();
                if (string.IsNullOrEmpty(entrada))
                {
                    Console.WriteLine("Dados da operação inválidos");
                    return;
                }
                string[] tradeData = entrada.Split(' ');

                if (tradeData.Length < 3)
                {
                    Console.WriteLine("Dados da operação incompletos");
                    return;
                }

                if (!double.TryParse(tradeData[0], out double value))
                {
                    Console.WriteLine("Valor inválido");
                    return;
                }

                string sector = tradeData[1];

                if (!DateTime.TryParseExact(tradeData[2], "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nextPaymentDate))
                {
                    Console.WriteLine("Data de pagamento inválida");
                    return;
                }

                trades.Add(new Trade(value, sector, nextPaymentDate));
            }

            Console.WriteLine("\nCategorias das operações:");
            foreach (var trade in trades)
            {
                Console.WriteLine(TradeCategorizer.CategorizeTrade(trade, dataDeReferencia));
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
