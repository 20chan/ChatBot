/*
 * 사용자: philly
 * 날짜: 2016-06-11
 * 시간: 오전 1:08
 */

 //#define PARSETEST

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
            //t.LoadKakaoTalkLog();
            //t.LoadTable("save.dat");

            Init(t);

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

        static void Init(CBR t)
        {
            t.AddConversation("안녕", "안녕하세요.");
            t.AddConversation("이름이 뭐야?", "제 이름은 <이름좀 정하자>입니다. 당신은요?");
            t.AddConversation("나는 이영찬이라고 해.", "만나서 반가워요.");
            t.AddConversation("만나서 반가워", "저도 만나서 반가워요.");
            t.AddConversation("나도", "그런가요?");
            t.AddConversation("1+1이 뭔지 알아?", "저를 시험하시는 건가요?");
            t.AddConversation("가장 좋아하는 영화가 뭐야?", "저는 '아이로봇'이라는 영화를 감명깊게 봤어요. 당신은요?");
            t.AddConversation("나는 를 가장 좋아해.", "저도 그거 좋아해요.");
            t.AddConversation("고마워.", "^^");
            t.AddConversation("가장 좋아하는 게 뭐야?", "글쎼요. 당신은요?");
            t.AddConversation("는 어때", "좋아요.");
        }
    }
}