using System;
using System.Text;

namespace LexicoGraphical
{
    class Program
    {
        static void Sort(ref String a, int n, ref int p)
        {
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder(a);
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if((strBuilder[i] == 'b' && strBuilder[j] == 'a') && p > 0)
                    {
                        char s = strBuilder[i];
                        strBuilder[i] = strBuilder[j];
                        strBuilder[j] = s;
                        p--;
                    }
            a = strBuilder.ToString();
        }

        static String LexSmallest(ref String a, int n, ref int p)
        {
            Sort(ref a, n, ref p);
            String answer = "";
            for (int i = 0; i < n; i++)
                answer += a[i];
            return answer;
        }

        static void Main(string[] args)
        {
            int n, p;
            Console.WriteLine("Enter n - ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter p - ");
            p = Convert.ToInt32(Console.ReadLine());
            String s;
            Console.WriteLine("Enter string using 'a' or 'b' only - ");
            s = Console.ReadLine();
            if (n < 1 || n > 105 || p < 0 || p > 2 * n)
            {
                Console.WriteLine("Invalid Input!");
                return;
            }
            for (int i = 0; i < s.Length; i++)
                if (s[i] != 'a' && s[i] != 'b')
                {
                    Console.WriteLine("Invalid String Input!");
                    return;
                }
            String answer = LexSmallest(ref s, n, ref p);
            int len = 0;
            while (p > 0)
            {
                System.Text.StringBuilder str = new System.Text.StringBuilder(s);
                if (str[len] == 'b')
                {
                    str[len] = 'a';
                    len++;
                    p -= 2;
                }
                else
                    len++;
                s = str.ToString();
            }
            Console.WriteLine(s);
        }
    }
}
