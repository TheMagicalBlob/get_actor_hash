using System;
using System.Collections.Generic;

namespace get_actor_hash
{
    class Program
    {
        static void Main(string[] args)
        {
            var pastConversions = new List<string>();
            string input;


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
                        Console.Clear();
                        Console.Write("Input: ");
                        input = Console.ReadLine();
                    }
                    while(input == null || input.Length < 1);
                }

                Console.Clear();      // Clear the screen
                input = input?.Trim() ?? string.Empty; // Remove any accidental whitespace wrapping the input


                // Check for clear command in input string
                if (input.ToLower() == "cls" || input.ToLower() == "clear")
                {
                    Console.Clear();
                    pastConversions = new List<string>();
                    continue;
                }
                pastConversions.Add($"{input} == ");



                // Hash input string
                ulong hash = 14695981039346656037;
                ulong prime = 1099511628211;
                foreach (char character in input)
                {
                    hash ^= character;
                    hash *= prime;
                }



                // Convert hash to a hexadecimal form,
                input = hash.ToString("X").PadLeft(16, '0');

                // Invert output hash endian for use in gamedata
                for (int i = input.Length - 2; i >= 0; i-=2)
                {
                    pastConversions[pastConversions.Count - 1] += $"{input[i]}{input[i+1]}";
                }
                pastConversions[pastConversions.Count - 1] +=  $"  |  {input}\n";


                // Ouptut all the hashed strings
                foreach (var str in pastConversions)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
