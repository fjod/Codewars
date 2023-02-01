using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;

namespace CodeWars
{
    class Program
    {
       
        public static int CoinChange(int[] coins, int amount)
        {
            // dp array which indicates least num of coins for each amount
            var dp = new long[amount + 1];
            for (int i = 0; i <= amount; i++)
                dp[i] = int.MaxValue; // init each amount with max coins
            dp[0] = 0; //if we need 0 amount then it will take 0 coins

            for (int currentAmount = 1; currentAmount <= amount; currentAmount++) //check each amount starting from 1
                foreach (var coin in coins) //check each coin
                    if (coin <= currentAmount) //if this coin is small enough to fit into current amount
                          //then decide:
                          //either we use previous coin for this amount 
                          //or we take previous amount for _this coin_ and increase current amount  
                          // so to fill 4 with (1,2) we can use 1+1+1+1 or 2+2
                        dp[currentAmount] = Math.Min(dp[currentAmount], dp[currentAmount - coin] + 1);

            //if it's not possible to find suitable coins, it means that last amount cant be collected from all coins
            // also it was no possible to collect this amount for each combination of coins in prev steps
            return dp[amount] > amount ? -1 : (int)dp[amount];
        }


        static void Main(string[] args)
        {
            var q = CoinChange(new []{3,7}, 11);
            q = CoinChange(new []{186,419,83,408}, 6249);
            Console.ReadKey();
        }
    }
}