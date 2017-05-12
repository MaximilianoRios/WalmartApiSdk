using DenDream.Marketplace.Walmart.SDK;
using DenDream.Marketplace.Walmart.SDK.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenDream.Marketplace.Walmart.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "pwyvatx2ujcrutpmysdm5sgc";
            var wrapper = new WalmartWrapper(apiKey);
            wrapper.ErrorReceived += Wrapper_ErrorReceived;

            Console.WriteLine("Searching....");
            Task.Run(async () =>
            {
                try
                {
                    var response = await wrapper.SearchAsync("Vintage Mario Bros with console");
                    Console.WriteLine("RESULT:");
                    Console.WriteLine($"Start: {response.Start}");
                    Console.WriteLine($"Items: {response.NumItems}");
                    Console.WriteLine($"Query: {response.Query}");
                    Console.WriteLine($"Response group: {response.ResponseGroup}");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });

            Console.WriteLine("Press any key to finish");
            Console.ReadLine();
        }

        private static void Wrapper_ErrorReceived(WalmartErrorResponse errorResponse)
        {
            Console.WriteLine("One or more errors have been received:");
            foreach (var error in errorResponse.Errors)
            {
                Console.WriteLine($"{error.Message} ({error.Code})");
            }
        }
    }
}
