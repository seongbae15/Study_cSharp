using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CheckPoint01
{
    class Program
    {
        static void Main(string[] args)
        {
            const string sideLine = "------------------------------";
            const int endLine = 30;
            const int delayTime = 200;

            int runA = 0;
            int runB = 0;
            int runC = 0;
            int runD = 0;
            Random rnd = new Random();
            
            while (true)
            {
                Console.Clear();

                Console.WriteLine(sideLine);
                for(int i=0;i<=endLine;i++)
                {
                    if(i == runA)
                        Console.Write("1");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("|");

                for (int i = 0; i <= endLine; i++)
                {
                    if (i == runB)
                        Console.Write("2");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("|");

                for (int i = 0; i <= endLine; i++)
                {
                    if (i == runC)
                        Console.Write("3");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("|");

                for (int i = 0; i <= endLine; i++)
                {
                    if (i == runD)
                        Console.Write("4");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("|");

                Console.WriteLine(sideLine);

                if (runA >= endLine || runB >= endLine || runC >= endLine || runD >= endLine)
                {
                    const string result = "결과 : {0} 우승!";
                    int winNum;
                    if (runA >= endLine)
                        winNum = 1;
                    else if (runB >= endLine)
                        winNum = 2;
                    else if (runC >= endLine)
                        winNum = 3;
                    else
                        winNum = 4;
                    Console.WriteLine(result, winNum);
                    Console.Write("Restart? Press 0 :   ");
                    if ("0" == Console.ReadLine())
                    {
                        runA = 0;
                        runB = 0;
                        runC = 0;
                        runD = 0;
                        continue;

                    }
                    else
                        break;

                }

                runA++;
                runB++;
                runC++;
                runD++;
                int rndNum = rnd.Next(0, 4);
                switch (rndNum)
                {
                    case 0:
                        runA++;
                        break;
                    case 1:
                        runB++;
                        break;
                    case 2:
                        runC++;
                        break;
                    case 3:
                        runD++;
                        break;
                }

                Thread.Sleep(delayTime);
            }
        }
    }
}
