namespace CodeWars;

public class cracking_ch8
{
    // 8.1 triple step
    public static int Stairs(int n)
    {
        int[] dp = new int[11];
        dp[1] = 1; 
        dp[2] = 2; 
        dp[3] = 4; 
            
        for (int i= 4; i <= n; i++)
        {
            dp[i] = dp[i - 1] + dp[i - 2] + dp[i - 3];
        }

        return dp[n];
    }
}