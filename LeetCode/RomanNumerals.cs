using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class RomanNumerals
    {
        
        public string IntToRoman(int num)
        {
            //Only I, X, C, and M can be repeated (up to 3 times); V, L, and D cannot be, and there is no need to do so.
            // 124 ==> CXXIV 1524 ==> MDXXIV"

            string result = string.Empty;
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int index = 0;
            foreach (int val in values)
            {
                while (val <= num)
                {
                    num = num - val;
                    result += romans[index];
                }
                index++;
            }

            return result;
            //string roman = "";
            //int thousands = num / 1000;
            //int fiveHundreds = (num % 1000) / 500;
            //int hundreds = ((num - fiveHundreds * 500) % 1000) / 100;
            //int fifys = (num % 100) / 50;
            //int tens = ((num - fifys * 50) % 100) / 10;
            //int fives = (num % 10) / 5;
            //int ones = ((num - fives * 5) % 10);

            //        Symbol	I	V	X	L	C	D	M
            //        Value  	1	5	10	50	100	500	1,000


            // "take away" from the five hundreds one per hundred over 3
            // e.x. 4 hundreds becomes 1 five hundred minus 1 hundred ==> CD

            //Console.WriteLine("thousands={0}, FiveHundreds={1} Hundreds={2} Fiftys={3}, tens={4} ones={5}",
            //    thousands, fiveHundreds, hundreds, fifys, tens, ones);

            //// 952 should go to ==> "CMLII"

            //for (int i = 0; i < thousands; i++)
            //{
            //    roman += "M";
            //}

            //for (int i = 0; i < fiveHundreds; i++)
            //{
            //    roman += "D";
            //}
            //if (hundreds > 3)
            //{
            //    int numCs = 5 - hundreds;
            //    for (int i = 0; i < numCs; i++)
            //    {
            //        roman += "C";
            //    }
            //    roman += "D";
            //    hundreds = 0;
            //}
            //for (int i = 0; i < hundreds; i++)
            //{
            //    roman += "C";
            //}
            //for (int i = 0; i < fifys; i++)
            //{
            //    roman += "L";
            //}
            //for (int i = 0; i < tens; i++)
            //{
            //    roman += "X";
            //}
            //for (int i = 0; i < fives; i++)
            //{
            //    roman += "V";
            //}
            //for (int i = 0; i < ones; i++)
            //{
            //    roman += "I";
            //}
            //return roman;
        }
    }
}
