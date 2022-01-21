using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckPoint02
{
    class Program
    {
        const string sideLine = "------------------------------";
        const int endLine = 30;
        const int delayTime = 200;

        static int runA = 0;
        static int runB = 0;
        static int runC = 0;
        static int runD = 0;


        static void ClearScreen()
        {
            Thread.Sleep(delayTime);
            Console.Clear();
        }

        static void RunProcess(Random rnd)
        {
            runA++;
            runB++;
            runC++;
            runD++;
            int rndNum = rnd.Next(0, 4);
            int rndRun = rnd.Next(0, 2);
            switch (rndNum)
            {
                case 0:
                    runA += rndRun;
                    break;
                case 1:
                    runB += rndRun;
                    break;
                case 2:
                    runC += rndRun;
                    break;
                case 3:
                    runD += rndRun;
                    break;
            }
        }

        static void UpdateScreen()
        {
            Console.WriteLine(sideLine);
            for (int i = 0; i <= endLine; i++)
            {
                if (i == runA)
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

        }

        static bool CheckResult()
        {
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
                    return true; ;
                }
                else
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();

            while (CheckResult())
            {
                ClearScreen();

                RunProcess(rnd);

                UpdateScreen();
            }

        }
    }
}
