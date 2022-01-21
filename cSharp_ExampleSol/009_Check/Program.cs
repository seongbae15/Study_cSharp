using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_Check
{
    class Program
    {
        static void InputID(int[] id, int index)
        {
            Console.WriteLine("학생 id를 입력하세요");
            id[index] = int.Parse(Console.ReadLine());
        }

        static void InputKor(int[] kor, int index)
        {
            Console.Write("국어 점수를 입력하세요?  ");
            kor[index] = int.Parse(Console.ReadLine());
        }
        static void InputMath(int[] math, int index)
        {
            Console.Write("수학 점수를 입력하세요?  ");
            math[index] = int.Parse(Console.ReadLine());
        }
        static void InputEng(int[] eng, int index)
        {
            Console.Write("영어 점수를 입력하세요?  ");
            eng[index] = int.Parse(Console.ReadLine());
        }

        static void PrintID(int max, int[] id)
        {
            for(int i = 0; i < max; i++)
            {
                Console.WriteLine("학생 id: {0}", id[i]);
            }
        }
        static int CheckID(int id, int max, int[] arrID)
        {
            for(int i=0;i<max;i++)
            {
                if(arrID[i] == id)
                {
                    return i;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            const int max = 3;
            int[] arrID = new int[max];
            int[] arrKor = new int[max];
            int[] arrMath = new int[max];
            int[] arrEng = new int[max];

            for(int i = 0; i < max; i++)
            {
                InputID(arrID, i);
                InputKor(arrKor, i);
                InputMath(arrMath, i);
                InputEng(arrEng, i);
                Console.WriteLine();
            }
            Console.Clear();

            int inputSel = 0;
            int selID = -1;


            while (true)
            {
                PrintID(max, arrID);
                Console.Write("학생 아이디를 입력하세요? (0)나가기  ");
                inputSel = int.Parse(Console.ReadLine());

                if (inputSel == 0)
                    break;
                selID = CheckID(inputSel, max, arrID);

                if (selID >= 0)
                {
                    Console.WriteLine("국어 점수:  {0}", arrKor[selID]);
                    Console.WriteLine("수학 점수:  {0}", arrMath[selID]);
                    Console.WriteLine("영어 점수:  {0}", arrEng[selID]);

                    int total = arrKor[selID] + arrMath[selID] + arrEng[selID];

                    Console.WriteLine("총점:  {0}", total);
                    Console.WriteLine("평균:  {0}", total / (float)max);
                    Console.WriteLine();
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("학생 아이디가 없어요. 다시 입력하세요");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        
    }
}
