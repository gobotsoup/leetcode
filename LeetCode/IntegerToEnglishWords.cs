using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class IntegerToEnglishWords
    {
        private Dictionary<int, string> numberToWords = new Dictionary<int, string>()
        {
            {1, "One"},{2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"},
            {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, {15, "Fifteen"}, {16, "Sixteen"},
            {17, "Seventeen"}, {18, "Eighteen" }, {19, "Nineteen" }
        };

            private Dictionary<int, string> tensToWords = new Dictionary<int, string>()
        {
            {2, "Twenty"}, {3, "Thirty"}, {4, "Forty"}, {5, "Fifty"}, {6, "Sixty"}, {7, "Seventy"}, {8, "Eighty"}, {9, "Ninety"}
        };
        //2147483647 is max number
        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";
            StringBuilder sb = new StringBuilder();
            int hundreds, tens;
            int billions = num / 1000000000;
            if (billions >= 1)
            {
                sb.Append($"{numberToWords[billions]} Billion ");
            }

            num = num % 1000000000;
            int millions = num / 1000000;
            if (millions >= 100)
            {
                hundreds = millions / 100;
                sb.Append($"{numberToWords[hundreds]} Hundred ");
                millions = millions % 100;
                if (millions == 0)
                {
                    sb.Append("Million ");
                }
            }

            if (millions >= 20)
            {
                tens = millions / 10;
                sb.Append($"{tensToWords[tens]} ");
                millions = millions % 10;
                if (millions == 0)
                {
                    sb.Append("Million ");
                }
            }

            num = num % 1000000;
            if (millions > 0)
            {
                sb.Append($"{numberToWords[millions]} Million ");
            }
            //else if (num == 0)
            //{
            //    return sb.Append("Million").ToString();
            //}
            int thousands = num / 1000;
            if (thousands >= 100)
            {
                hundreds = thousands / 100;
                sb.Append($"{numberToWords[hundreds]} Hundred ");
                thousands = thousands % 100;
                if (thousands == 0)
                {
                    sb.Append("Thousand ");
                }
            }

            if (thousands >= 20)
            {
                tens = thousands / 10;
                sb.Append($"{tensToWords[tens]} ");
                thousands = thousands % 10;
                if (thousands == 0)
                {
                    sb.Append("Thousand ");
                }
            }
            if (thousands > 0)
            {
                sb.Append($"{numberToWords[thousands]} Thousand ");
            }

            num = num % 1000;
            hundreds = num / 100;
            if (hundreds > 0)
            {
                sb.Append($"{numberToWords[hundreds]} Hundred ");
            }

            num = num % 100;
            tens = num / 10;
            if (tens >= 2)
            {
                sb.Append($"{tensToWords[tens]} ");
            }

            if (tens == 1)
            {
                sb.Append($"{numberToWords[num]} ");
                return sb.ToString().Trim();
            }

            num = num % 10;
            if (num >= 1)
            {
                sb.Append($"{numberToWords[num]}");
            }

            return sb.ToString().Trim();
        }
    }
}
