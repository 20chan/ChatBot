/*
 * 사용자: philly
 * 날짜: 2016-06-11
 * 시간: 오전 1:25
 */
using System;
using System.Collections.Generic;

namespace ChatBot
{
	public static class Parser
	{
		private static List<string> userLess = new List<string>()
		{
			"a", "an", "the",
			"am", "is", "are", "was", "were"
		};
		public static string[] ParseKorean(string input)
		{
			List<string> result = new List<string>();
			
			foreach(string s in input.Split(null))
			{
				string low = s.ToLower();
				if(!userLess.Contains(low))
					result.Add(low);
			}
			
			return result.ToArray();
		}
	}
}
