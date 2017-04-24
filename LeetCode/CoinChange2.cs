using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    //    You are given coins of different denominations and a total amount of money.Write a function to compute the number of combinations that make up that amount.
    //      You may assume that you have infinite number of each kind of coin.
//Note: You can assume that

//0 <= amount <= 5000
//1 <= coin <= 5000
//the number of coins is less than 500
//the answer is guaranteed to fit into signed 32-bit integer
    public class CoinChange2
    {
        public static int Change(int amount, int[] coins)
        {
            //combos[upToIndex][amount] = numCombos
            int[,] combos = new int[coins.Length+1, amount+1];

            // there is 1 combination to make it to amount of 0
            combos[0, 0] = 1;

            // i is the "current" index, i-1 is looking back at what has been accumulated for this amount
            for (int i = 1; i <= coins.Length; i++)
            {
                // there is 1 combination to make it to amount of 0
                combos[i, 0] = 1;

                for (int j = 1; j <= amount; j++)
                {
                    int coinValue = coins[i-1];
                    if (coinValue > j)
                    {
                        combos[i, j] = combos[i - 1, j];
                        continue;
                    }

                    int numCombosUpToThisAmount = combos[i, j - coinValue];
                    int numCombosSoFar = combos[i-1, j];
                    combos[i,j] = numCombosUpToThisAmount + numCombosSoFar;                    
                }
            }

            return combos[coins.Length, amount];
        }

        public static int RealChange(int amount, int[] coins)
        {
            int[,] dp = new int[coins.Length + 1, amount + 1];
            dp[0,0] = 1;

            for (int i = 1; i <= coins.Length; i++)
            {
                dp[i, 0] = 1;
                for (int j = 1; j <= amount; j++)
                {
                    dp[i, j] = dp[i - 1, j] + (j >= coins[i - 1] ? dp[i, j - coins[i - 1]] : 0);
                }
            }
            return dp[coins.Length, amount];
        }
    }
}
