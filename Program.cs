using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text.Json.Nodes;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace tracking_api
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            // Build a config object, using env vars and JSON providers.
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            // Get values from the config given their key and their target type.
            Settings? settings = config.GetRequiredSection("Settings").Get<Settings>();

            IToken? tokenObj = null;

            while (true)
            {
                //User input tracking number
                Console.WriteLine("Enter tracking number (multi numbers separate by comma):"); // tracking number demo: "794843185271"

                string trackingNumber = Console.ReadLine();
                
                if (tokenObj is null)
                {
                    tokenObj = await Services.GetToken(settings!);
                }
                else
                {
                    //token expire in 1 hour
                    var diffInSeconds = (DateTime.Now - tokenObj.createDate).TotalSeconds;
                    if(diffInSeconds >= 3600)
                    {
                        tokenObj = await Services.GetToken(settings!);
                    }
                }

                if (tokenObj != null && trackingNumber !=null)
                {
                    var arrayNumber = trackingNumber.Split(",").Select(x => x.Trim()).ToList();
                    var batchSize = settings!.MaxLimit;
                    var totalBatch = (int)Math.Ceiling((double)arrayNumber.Count() / batchSize);

                    for (int i = 0; i < totalBatch; i++) {
                        Console.WriteLine($"Getting status (batch {i + 1})...");
                        var arrayBatch = arrayNumber.Skip(i * batchSize).Take(batchSize).ToList();
                        await Services.GetStatus(settings!, tokenObj.AccessToken, arrayBatch);

                        //wait 1 second for next request
                        await Task.Delay(1000);
                    }
                    Console.WriteLine("Get status done!");
                    Console.WriteLine("");
                }
            }
            
        }
    }
}


