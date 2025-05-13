using System.Collections.Generic;
using System.Linq;

namespace CsharpAlgorithm.Source.Algorithm.Programmers.Challenge
{
    public class ServerExpansion
    {
        public int Solution(int[] players, int m, int k)
        {
            int answer = 0;
            answer = CheckServer(players, m, k);
            return answer;
        }

        private int CheckServer(int[] players, int m, int k)
        {
            var length = players.Length;
            var result = 0;

            Queue<int> serverTimer = new Queue<int>();

            for (int i = 0; i < length; i++)
            {
                RemoveServer(serverTimer);

                var player = players[i];
                var needCount = (int)(player / m);

                if (needCount > 0 && (serverTimer.Count < needCount))
                {
                    var addCount = needCount - serverTimer.Count;

                    for (int j = 0; j < addCount; j++)
                    {
                        serverTimer.Enqueue(k);
                        result++;
                    }
                }
            }

            return result;
        }

        private void RemoveServer(Queue<int> serverTimer)
        {
            if (serverTimer.Count == 0)
                return;

            var count = serverTimer.Count;

            for (int i = 0; i < count; i++)
            {
                var timer = serverTimer.Dequeue();
                timer--;

                if (timer > 0)
                    serverTimer.Enqueue(timer);
            }
        }
    }
}