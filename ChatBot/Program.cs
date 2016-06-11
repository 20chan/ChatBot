/*
 * 사용자: philly
 * 날짜: 2016-06-11
 * 시간: 오전 1:08
 */
using System;

namespace ChatBot
{
	class Program
	{
		public static void Main(string[] args)
		{
			CBR t = new CBR();
			//t.LoadTable("save.dat");
			
			while(true)
			{
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write("You : ");
				string read = Console.ReadLine();
				Console.WriteLine();
				
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Bot : " + t.Eval(read));
				Console.WriteLine();
			}
		}
	}
}