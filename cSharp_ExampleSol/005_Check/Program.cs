using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_Check
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int a;
            int b;

            int inputNum = 0;
            int check = 1;
            int correct = 0;
            while(true)
            {
                a = rnd.Next(1, 100);
                b = rnd.Next(1, 100);

                Console.WriteLine("{0}. 다음 두 수의 합은?", check);
                Console.Write("{0} + {1} = ", a, b);
                inputNum = int.Parse(Console.ReadLine());

                if((a+b) == inputNum)
                {
                    Console.WriteLine("*** 정답 ***");
                    correct++;
                }
                else
                    Console.WriteLine("*** 오답 ***");

                if(check++ >= 5)
                {
                    Console.WriteLine("\n*** 결과 ***");
                    Console.WriteLine("총 정답 수:{0}", correct);
                    break;
                }
            }
        }
    }
}
