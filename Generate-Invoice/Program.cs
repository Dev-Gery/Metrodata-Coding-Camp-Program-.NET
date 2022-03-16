using System;
using System.Text.RegularExpressions;
namespace GenerateInvoice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.Write("INPUT A NUMBER: ");
                input = Console.ReadLine();
            } while (!Regex.IsMatch(input, "[0-9]"));
            string output = GenerateInvoice(input);
            Console.WriteLine(output);
        }
        static string GenerateInvoice(string input)
        {
            int newInputNum = int.Parse(input) + 1;
            DateTime currentDate = DateTime.Now;
            //ToString("dd/MM/yyyy")
            currentDate = currentDate.AddDays(3);
            string theDate = currentDate.ToString("dd/MM/yyyy");
            string[] arrayTheDate = theDate.Split('/');
            string dayAbreviated = DateTime.Now.ToString("ddd");
            string dy = dayAbreviated.Substring(0, 2);
            string ddInRoman = ToRoman(int.Parse(arrayTheDate[0]));
            string yyInRoman = ToRoman(int.Parse(arrayTheDate[2].Substring(2)));
            string invoice = $"INV/{arrayTheDate[2]}{arrayTheDate[1]}/{dy.ToUpper()}/{ddInRoman}/{yyInRoman}/" + newInputNum;
            return invoice;
        }
        static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Masukkan nilai antara 1 dan 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("terjadi kesalahan");
        }
    }
}
