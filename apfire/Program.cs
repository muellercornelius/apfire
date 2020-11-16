using System;
using System.Collections.Generic;
using System.Linq;

namespace apfire
{
    class Program
    {
        private static readonly string[] possibleArgs = { "url", "d", "c", "h", "m" };
        static void Main(string[] args)
        {
            while (true)
            {
                start();
                readInputAndParseArguments();
            }
        }

        static void start()
        {
            print("Set your API on Fire");
            print("Please provide the url you want to light up");
        }

        static void readInputAndParseArguments()
        {
            string command = Console.ReadLine();
            string[] args = command.Split('-').Select(arg => arg.Trim()).ToArray();
            string[] cleanedArgs = args.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            Dictionary<string, string> parsedArgs = new Dictionary<string, string>();
            foreach (var arg in cleanedArgs)
            {
                if (possibleArgs.Contains(arg.Split(" ")[0])) {
                    string argKey = arg.Split(" ")[0];
                    try { 
                    string argValue = arg.Split(" ")[1];
                        try
                        {
                            parsedArgs.Add(argKey, argValue);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("An element with Key = " + argKey + " already exists.");
                        }
                    } catch (IndexOutOfRangeException)
                    {
                        print("You havent specified a value for your argument... Skipping");
                    }
                } else
                {
                    print("Error: The Argument " + arg + " is not valid");
                    return;
                }
            }

            Site site1 = new Site()
            {
                url = parsedArgs.ContainsKey("url") ? parsedArgs["url"] : "localhost:3000",
                debugMode = parsedArgs.ContainsKey("d") ? parsedArgs["d"] : "suppress",
                method = parsedArgs.ContainsKey("d") ? parsedArgs["m"] : "GET",
                hitCount = parsedArgs.ContainsKey("c") ? int.Parse(parsedArgs["c"]) : 1000,
            };
            site1.testApiEndpoint();
        }
        
        static void print(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
