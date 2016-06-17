/*
 * 사용자: philly
 * 날짜: 2016-06-11
 * 시간: 오전 1:25
 */
using System;
using System.Collections.Generic;
using kr.ac.kaist.swrc.jhannanum.comm;
using kr.ac.kaist.swrc.jhannanum.hannanum;
namespace ChatBot
{
    public static class Parser
    {
        private static List<string> Josa = new List<string>()
        {
            "은", "는", "를", "이", "가", "나", "어", "지", "고", "거", "아", "내", "있", "요", "네", "하", "로", "을지", "답니다", "도", "에", "ㅂ니다", "는데요", "었는데" ,"의" ,"이르", "어는", "게" ,"어다" ,"니" ,"에게"
        };

        static Workflow workflow;
        public static string[] ParseKorean(string input)
        {
            if (input == null) return new string[] { };
            if (String.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input)) return new string[] { };
            if (workflow == null)
            {
                workflow = WorkflowFactory.getPredefinedWorkflow(WorkflowFactory.WORKFLOW_POS_SIMPLE_09);
                workflow.activateWorkflow(true);
            }

            workflow.analyze(input);
            LinkedList<Sentence> result = workflow.getResultOfDocument(new Sentence(0, 0, false));

            List<string> res = new List<string>();
            foreach (Sentence s in result)
            {
                Eojeol[] eojeolArray = s.Eojeols;
                for (int i = 0; i < eojeolArray.Length; i++)
                {
                    if (eojeolArray[i].length > 0)
                    {
                        String[] morphemes = eojeolArray[i].Morphemes;
                        for (int j = 0; j < morphemes.Length; j++)
                        {
                            if (Josa.Contains(morphemes[j])) continue;
                            res.Add(morphemes[j]);
                        }
                    }
                }
            }

            return res.ToArray();
        }

        public static string ParseKakaotalkLog(string line)
        {
            if (line == null) return "";
            string[] spl = line.Split(':');
            if (spl.Length < 3) return "";
            return line.Substring(spl[0].Length + spl[1].Length + 3);
        }
    }
}