using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckPoint03
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
        static void InitGame(int[] arrIndex, int[,] map)
        {
            for(int i=0;i<arrIndex.Length;i++)
            {
                arrIndex[i] = 0;
            }
            int firstPlayer = 3;
            int height = map.GetLength(0);
            int width = map.GetLength(1);

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    if (h == 0 || h == height - 1)
                    {
                        map[h, w] = 1;
                    }
                    else
                    {
                        if (w == 0)
                        {
                            map[h, w] = firstPlayer;
                            firstPlayer++;
                        }
                        else if (w == width - 1)
                            map[h, w] = 2;
                        else
                            map[h, w] = 0;
                    }
                }
            }
        }
        static void DispScreen(char[] tile,int[,] map)
        {
            int height = map.GetLength(0);
            int width = map.GetLength(1);
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Console.Write(tile[map[h, w]]);
                }
                Console.WriteLine();
            }
        }

        static void ClearView(int delay_time)
        {
            Thread.Sleep(delay_time);
            Console.Clear();

        }

        static void UpateGo(int[] arrIndex,int[,] map)
        {
            for (int i=0;i< arrIndex.Length; i++)
            {
                map[i + 1, arrIndex[i] + 1] = map[i + 1, arrIndex[i]];
                map[i+1, arrIndex[i]] = 0;
                if(arrIndex[i] < 21)
                    arrIndex[i]++;
            }
        }
        static void RandomGo(Random rnd, int[] arrIndex, int[,] map)
        {
            int rndIndex = rnd.Next(0, arrIndex.Length);

            map[rndIndex + 1, arrIndex[rndIndex] + 1] = map[rndIndex + 1, arrIndex[rndIndex]];
            map[rndIndex + 1, arrIndex[rndIndex]] = 0;
            if (arrIndex[rndIndex] < 21)
                arrIndex[rndIndex]++;

        }
        static bool CheckGameEnd(int[] arrIndex)
        {
            for (int i = 0; i < arrIndex.Length; i++)
            {
                if (arrIndex[i] >= 21)
                {
                    Console.WriteLine();
                    Console.WriteLine("Result: {0} Win",i+1);
                    return true;
                }
            }
            return false;
        }
        static bool CheckRestart()
        {
            if (int.Parse(Console.ReadLine()) == 0)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            char[] tile = { ' ', '-', '|', '1', '2', '3', '4','5' };
            const int height = 7;
            const int width = 22;
            const int delay_time = 300;
            int[,] map = new int[height, width];

            int[] arrIndex = { 0, 0, 0, 0, 0 };
            InitGame(arrIndex, map);
            Random rnd = new Random();
            while (true)
            {
                if(CheckGameEnd(arrIndex))
                {
                    Console.Write("Restart? Prees 0 : ");
                    if (CheckRestart())
                        InitGame(arrIndex, map);
                    else
                        break;
                }
                ClearView(delay_time);
                DispScreen(tile, map);
                UpateGo(arrIndex, map);
                RandomGo(rnd, arrIndex, map);

            }


            //while (CheckResult())
            //{
            //    ClearScreen();

            //    RunProcess(rnd);

            //    UpdateScreen();
            //}

        }
    }
}

