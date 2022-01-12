using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Check
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int rndNum = rnd.Next(1, 100);
            int inputNum = 0;
            int check = 0;

            Console.WriteLine("0~99 Up? Down? (0: Exit)");
            while (true)
            {
                inputNum = int.Parse(Console.ReadLine());
                if (0 == inputNum)
                    break;
                ++check;
                if (inputNum > rndNum)
                    Console.WriteLine("Down");
                else if (inputNum < rndNum)
                    Console.WriteLine("Up");
                else
                {
                    Console.WriteLine("정답");
                    Console.WriteLine("Try : {0}", check);
                    break;
                }
            }

        }

    }
}
