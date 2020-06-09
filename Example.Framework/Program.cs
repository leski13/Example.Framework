using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Example.Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution("XIXI"));
            Console.WriteLine(Solution("X"));
            Console.WriteLine(Solution("IXI"));
            Console.WriteLine(Solution("D"));
            Console.ReadLine();
        }

        public static int Solution(string roman)
        {
            int count=0;
            Dictionary<char, int> symbol = new Dictionary<char, int>()
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };
            
            for(int s = 0; s < roman.Length; s++)
            {
                if (symbol.ContainsKey(roman[s]))
                {
                    if ((s+1)==roman.Length)
                    {
                        symbol.TryGetValue(roman[s], out int res3);
                        count += res3;
                        break;
                    }
                    symbol.TryGetValue(roman[s], out int res);
                    symbol.TryGetValue(roman[s+1], out int res2);

                    count = res >= res2 ? count += res : count += (res2 - res);
                    if (res < res2) s++;
                }   
            }
            return count;
        }
    }
}
