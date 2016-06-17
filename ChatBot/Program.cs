/*
 * 사용자: philly
 * 날짜: 2016-06-11
 * 시간: 오전 1:08
 */

 #define PARSETEST

using System;

namespace ChatBot
{
	class Program
	{
		public static void Main(string[] args)
		{
#if PARSETEST
            while (true) {
                string[] str = Parser.ParseKorean(Console.ReadLine());
                foreach (string s in str)
                    Console.Write(s + ", ");
                Console.WriteLine(); }
# else
            CBR t = new CBR();
            t.LoadKakaoTalkLog();
            //t.LoadTable("save.dat");
            System.Windows.Forms.MessageBox.Show("학습이 완료되었습니다!");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("You : ");
                string read = Console.ReadLine();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bot : " + t.Eval(read));
                Console.WriteLine();
            }
#endif
        }
    }
}