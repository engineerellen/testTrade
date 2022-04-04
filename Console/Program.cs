
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Servico.Interface;
using Domain.Servico;
using Newtonsoft.Json;

namespace ConsoleBank
{
    public class Program
    {

        static IProccessService _processService;
 
        static void Main(string[] args)
        {
            args = new string[] { @"12/11/2020
4
2000000 Private 12/29/2025
400000 Public 07/01/2020
5000000 Public 01/02/2024
3000000 Public 10/26/2023
" };
            RunAsync(args);
        }

        static async void RunAsync(string[] args)
        {
            Console.WriteLine("Application starting.");
            Console.WriteLine("Input:");
            Console.WriteLine(String.Concat(args));

            _processService = new ProccessService();
            var retorno = await _processService.ProccessTradeInput(String.Concat(args));
            var processedItens = await _processService.ProccessOutputClassification(retorno);
            retorno.Items = processedItens.Items;

            Console.WriteLine("String Output:");

            foreach (var item in retorno.Items)
                Console.WriteLine(item.OutputClassification + Environment.NewLine);

            Console.WriteLine("Json Output:");
            string json = JsonConvert.SerializeObject(retorno);
            Console.WriteLine(json);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
