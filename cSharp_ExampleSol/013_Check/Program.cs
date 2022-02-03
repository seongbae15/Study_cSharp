using System;
using System.Collections;

namespace _013_Check
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

    class CStManager
    {
        Hashtable hashStudents;

        public CStManager()
        {
            hashStudents = new Hashtable();
        }
        public void RegisterStudents()
        {
            while (true)
            {
                PrintID();
                Console.Write("===== 성적 입력 중 ===== < (0) 나가기 > : ");
                if(Console.ReadLine() == "0")
                    break;
                CStudent tempSt = new CStudent();
                tempSt.InputID();
                tempSt.InputKor();
                tempSt.InputMath();
                tempSt.InputEng();

                hashStudents.Add(tempSt.ID, tempSt);
                Console.WriteLine();
            }
        }


        public void PrintID()
        {
            foreach(int key in hashStudents.Keys)
            {
                Console.WriteLine("학생 id: {0}", ((CStudent)hashStudents[key]).ID);
            }
        }
        public int CheckID(int id)
        {
            if (hashStudents.ContainsKey(id))
                return id;
            return -1;
        }
        public void ShowScore(int id)
        {
            int kor = ((CStudent)hashStudents[id]).KOR;
            int math = ((CStudent)hashStudents[id]).MATH;
            int eng = ((CStudent)hashStudents[id]).ENG;
            Console.WriteLine("국어 점수:  {0}", kor);
            Console.WriteLine("수학 점수:  {0}", math);
            Console.WriteLine("영어 점수:  {0}", eng);

            int total = kor + math + eng;

            Console.WriteLine("총점:  {0}", total);
            Console.WriteLine("평균:  {0}", total / 3f);

        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            CStManager stManager = new CStManager();
            stManager.RegisterStudents();
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
