using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LargestNumberProblem
    {
        public string LargestNumber(int[] nums)
        {
            string largestNumAsString = "";
            //Console.WriteLine($"Before: {string.Join(",", nums)}");
            Array.Sort(nums, CompareNums);
            //Console.WriteLine($"After: {string.Join(",", nums)}");
            
            foreach (int num in nums)
            {
                if (largestNumAsString == "0" && num == 0) break;
                largestNumAsString = $"{largestNumAsString}{num}";
            }

            return largestNumAsString;
        }

        public static int CompareNums(int num1, int num2)
        {
            string num1String = num1.ToString();
            string num2String = num2.ToString();
            int totalPossibleLength = num1String.Length + num2String.Length;
            int num1Index = 0;
            int num2Index = 0;
            bool flip1 = false;
            bool flip2 = false;
            var sb1 = new StringBuilder();
            var sb2 = new StringBuilder();
            for (int i = 0; i < totalPossibleLength; i++)
            {
                if (num1Index > num1String.Length - 1)
                {
                    num1Index = 0;
                    flip1 = true;
                }
                if (num2Index > num2String.Length - 1)
                {
                    num2Index = 0;
                    flip2 = true;
                }
                char c1 = flip1 ? num2String[num1Index] : num1String[num1Index];
                char c2 = flip2 ? num1String[num2Index] : num2String[num2Index];
                num1Index++;
                num2Index++;
                sb1.Append(c1);
                sb2.Append(c2);
                if (c1 != c2)
                {
                    int number1, number2;
                    int.TryParse(sb1.ToString(), out number1);
                    int.TryParse(sb2.ToString(), out number2);
                    if (number2 > number1) return 1;
                    return -1;
                }
            }

            return 0;
        }
    }
}
