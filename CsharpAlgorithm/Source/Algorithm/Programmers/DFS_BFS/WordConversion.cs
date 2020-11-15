using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class WordConversion
    {
        bool[] visited = new bool[50];
        public WordConversion()
        {
            Console.WriteLine(Solution("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" }));
            Console.WriteLine(Solution("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log" }));
        }

        public int Solution(string begin, string target, string[] words)
        {
            int answer = 0;

            if (words.Contains(target))
            {
                answer = DFS(begin, target, words);
            }

            return answer;
        }

        public int DFS(string begin, string target, string[] words)
        {
            int answer = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (!visited[i])
                {
                    int count = 0;

                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if (begin[j] == words[i][j])
                        {
                            count++;
                        }
                    }

                    if (count == words[i].Length - 1)
                    {
                        visited[i] = true;
                        begin = words[i];

                        if (begin == target)
                        {
                            return 1;
                        }
                        else
                        {
                            answer += DFS(begin, target, words) + 1;
                        }
                    }
                }
            }

            return answer;
        }
    }
}
