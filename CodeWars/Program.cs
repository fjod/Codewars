namespace CodeWars
{
    class Program
    {
      
        public static void ReverseString(char[] s) {
                Reverse(s, 0, s.Length - 1);
        }

        static void Reverse(char[] s, int left, int right)
        {
            if (left >= right) return;
            (s[left], s[right]) = (s[right], s[left]);
            Reverse(s, left+1, right-1);
        }
   

     

        static void Main(string[] args)
        {
            var input = new[] {'h', 'e', 'l', 'l', 'o'};
           ReverseString(input);
           ReverseString(input);
        }
    }
}