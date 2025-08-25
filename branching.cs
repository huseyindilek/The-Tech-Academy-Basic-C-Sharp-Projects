using System;
using System.Globalization;

namespace PackageExpressApp
{
    internal class Program
    {
        private static readonly CultureInfo Us = CultureInfo.GetCultureInfo("en-US");
        private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

        static void Main(string[] args)
        {
            // Exact required opening line
            Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

            // Weight
            decimal weight = ReadDecimal("Please enter the package weight:");
            if (weight > 50m)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
                return;
            }

            // Width, Height, Length in this exact order
            decimal width  = ReadDecimal("Please enter the package width:");
            decimal height = ReadDecimal("Please enter the package height:");
            decimal length = ReadDecimal("Please enter the package length:");

            // Sum-of-dimensions rule
            if ((width + height + length) > 50m)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
                return;
            }

            // Quote = (H * W * L * Weight) / 100
            decimal quote = (height * width * length * weight) / 100m;

            // Show as US dollars with two decimals
            string price = quote.ToString("C2", Us);
            Console.WriteLine($"Your estimated total for shipping this package is: {price}");
            Console.WriteLine("Thank you!");
        }
        private static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string? s = Console.ReadLine();

                if (decimal.TryParse(s, NumberStyles.Number, Inv, out var value) && value >= 0m)
                    return value;
   
            }
        }
    }
}
