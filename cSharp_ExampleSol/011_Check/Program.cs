using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _011_Check
{
    class CStudent
    {
        private int id;
        private int kor;
        private int math;
        private int eng;

        public int ID { get { return id; } }
        public int KOR { get { return kor; } }
        public int MATH { get { return math; } }
        public int ENG { get { return eng; } }

        public CStudent()
        {
            this.id = 0;
            this.kor = 0;
            this.math = 0;
            this.eng = 0;
        }
        public void InputID()
        {
            Console.WriteLine("학생 id를 입력하세요");
            this.id = int.Parse(Console.ReadLine());
        }
        public void InputKor()
        {
            Console.Write("국어 점수를 입력하세요?  ");
            this.kor = int.Parse(Console.ReadLine());
        }
        public void InputMath()
        {
            Console.Write("수학 점수를 입력하세요?  ");
            this.math = int.Parse(Console.ReadLine());
        }
        public void InputEng()
        {
            Console.Write("영어 점수를 입력하세요?  ");
            this.eng = int.Parse(Console.ReadLine());
        }

    }

    class CStManager {
        private CStudent[] students;

        public void RegisterStudents(int count)
        {
            students = new CStudent[count];
            for (int i=0;i< count; i++)
            {
                students[i] = new CStudent();
                students[i].InputID();
                students[i].InputKor();
                students[i].InputMath();
                students[i].InputEng();
            }
        }


        public void PrintID()
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("학생 id: {0}", students[i].ID);
            }
        }
        public int CheckID(int id)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].ID == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public void ShowScore(int id)
        {
            Console.WriteLine("국어 점수:  {0}", students[id].KOR);
            Console.WriteLine("수학 점수:  {0}", students[id].MATH);
            Console.WriteLine("영어 점수:  {0}", students[id].ENG);

            int total = students[id].KOR + students[id].MATH + students[id].ENG;

            Console.WriteLine("총점:  {0}", total);
            Console.WriteLine("평균:  {0}", total / 3f);

        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            const int MAX = 3;
            CStManager stManager = new CStManager();
            stManager.RegisterStudents(MAX);
            Console.Clear();

            int inputSel = 0;
            int selID = -1;


            while (true)
            {
                stManager.PrintID();
                Console.Write("학생 아이디를 입력하세요? (0)나가기  ");
                inputSel = int.Parse(Console.ReadLine());

                if (inputSel == 0)
                    break;
                selID = stManager.CheckID(inputSel);

                if (selID >= 0)
                {
                    stManager.ShowScore(selID);
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
