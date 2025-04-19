using System;
using System.Collections.Generic;

namespace t2hash
{
    class Program
    {
        static void Main(string[] args)
        {
            var pastConversions = new List<string>();
            var input = string.Empty;

            ulong offset_basis = 14695981039346656037;
            ulong prime = 1099511628211;
            ulong hash;


            while (true)
            {
                // Aquire input string
                if (args.Length > 0)
                {
                    input = args[0];
                    args = Array.Empty<string>();
                }
                else {
                    do {
                        Console.Write("Input: ");
                        input = Console.ReadLine();
                    }
                    while(input == null || input.Length < 1);
                }

                Console.Clear();      // Clear the screen
                input = input.Trim(); // Remove any accidental whitespace wrapping the input


                // Check for clear command in input string
                if (input.ToLower() == "cls" || input.ToLower() == "clear")
                {
                    Console.Clear();
                    pastConversions = new List<string>();
                    continue;
                }
                pastConversions.Add($"{input} == ");


                // Hash input string
                hash = offset_basis;
                foreach (char character in input)
                {
                    hash ^= character;
                    hash *= prime;
                }


                input = hash.ToString("X");

                for (int i = input.Length - 2; i >= 0; i-=2)
                {
                    pastConversions[pastConversions.Count - 1] += $"{input[i]}{input[i+1]}";
                }
                pastConversions[pastConversions.Count - 1] +=  $"/ {input}\n";
                
                Array.ForEach(pastConversions.ToArray(), str => Console.WriteLine(str));
            }
        }
    }
}
