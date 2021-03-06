﻿using DenDream.Marketplace.Walmart.SDK;
using DenDream.Marketplace.Walmart.SDK.Exceptions;
using DenDream.Marketplace.Walmart.SDK.Model;
using DenDream.Marketplace.Walmart.SDK.Model.Request;
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
            var apiKey = "your search key";
            var wrapper = new WalmartWrapper(apiKey);

            Console.WriteLine("Searching....");
            Task.Run(async () =>
            {
                try
                {
                    var facetsBuilder = new FacetsFilterBuilder();
                    // facetsBuilder.AddFilter("retailer", "Odyssey Computers");
                    // facetsBuilder.AddRange("price", 100, 200);

                    SearchParametersFactory factory = new SearchParametersFactory();
                    var searchParameters = factory.Get("notebook hp", null, 25, 1, true, facetsBuilder.Filters, facetsBuilder.Ranges);

                    var response = await wrapper.SearchAsync(searchParameters);

                    Console.WriteLine("RESULT:");
                    Console.WriteLine($"Start: {response.Start}");
                    Console.WriteLine($"Items: {response.NumItems}");
                    Console.WriteLine($"Query: {response.Query}");
                    Console.WriteLine($"Response group: {response.ResponseGroup}");

                    Console.WriteLine("ITEMS:");
                    foreach (var item in response.Items)
                    {
                        Console.WriteLine($"{item.Id} - {item.Name} (${item.SalePrice}) ({item.AvailableOnline})");
                    }

                    // Force an invalid search
                    var invalidSearch = await wrapper.SearchAsync(new SearchParameters());
                }
                catch(WalmartOperationException operationException)
                {
                    ShowErrors(operationException.ErrorResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    throw ex;
                }
            });

            Console.WriteLine("Press any key to finish");
            Console.ReadLine();
        }

        private static void ShowErrors(WalmartErrorResponse errorResponse)
        {
            Console.WriteLine("One or more errors have been received:");
            foreach (var error in errorResponse.Errors)
            {
                Console.WriteLine($"{error.Message} ({error.Code})");
            }
        }
    }
}
