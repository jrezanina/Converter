using System;

namespace Converter
{
    class Converter
    {
        private static string StringReverse(string s)
        {
            if (s.Length > 0)
                return s[s.Length - 1] + StringReverse(s.Substring(0, s.Length - 1));
            else
                return s;
        }
        public static string DecToBin(int dec)
        {
            string bin = "";
            while (dec > 0)
            {
                bin += Convert.ToString(dec%2);
                dec /= 2;
            }
            return StringReverse(bin);
        }

        public static int BinToDec(string bin)
        {
            bin = StringReverse(bin);
            int dec = 0;
            for (int i = 0; i < bin.Length; i++)
                dec += Convert.ToInt32(Char.GetNumericValue(bin[i])*Math.Pow(2,i));       
            return dec;
        }

        public static int BinToOct(string bin)
        {
            int loops = bin.Length / 3;
            int startIndex = bin.Length % 3;
            string oct = "";
            if (startIndex!=0)
                oct += BinToDec(bin.Substring(0,startIndex));
            for (int i = 0; i<loops; i++)
                oct += BinToDec(bin.Substring(startIndex+i*3, 3));
            return Convert.ToInt32(oct);
        }

        public static string OctToBin(int oct)
        {
            string octStr = oct.ToString();
            string bin = "";
            for (int i = 0; i < octStr.Length; i++)
            {
                if (Convert.ToInt32(Char.GetNumericValue(octStr[i])) == 0)
                    bin += "000" + DecToBin(Convert.ToInt32(Char.GetNumericValue(octStr[i])));
                else if (Convert.ToInt32(Char.GetNumericValue(octStr[i])) == 1)
                    bin += "00" + DecToBin(Convert.ToInt32(Char.GetNumericValue(octStr[i])));
                else if (Convert.ToInt32(Char.GetNumericValue(octStr[i])) > 1 && Convert.ToInt32(Char.GetNumericValue(octStr[i])) < 4)
                    bin += "0"+DecToBin(Convert.ToInt32(Char.GetNumericValue(octStr[i])));
                else
                    bin += DecToBin(Convert.ToInt32(Char.GetNumericValue(octStr[i])));

            }
            return bin;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadejte číslo v desítkové soustavě pro převod do dvojkové: ");
            Console.WriteLine("Výsledek: " + Converter.DecToBin(Convert.ToInt32(Console.ReadLine())));
            Console.Write("Zadejte číslo v dvojkové soustavě pro převod do desítkové: ");
            Console.WriteLine("Výsledek: " + Converter.BinToDec(Console.ReadLine()));
            Console.Write("Zadejte číslo v dvojkové soustavě pro převod do oktanové: ");
            Console.WriteLine("Výsledek: " + Converter.BinToOct(Console.ReadLine()));
            Console.Write("Zadejte číslo v oktanové soustavě pro převod do dvojkové: ");
            Console.WriteLine("Výsledek: " + Converter.OctToBin(Convert.ToInt32(Console.ReadLine())));
        }
    }
}
