using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 정수 삼각형 https://programmers.co.kr/learn/courses/30/lessons/43105
    /// </summary>
    class IntegerTriangle
    {
        public IntegerTriangle()
        {
            List<List<int>> inputTriangleList = new List<List<int>>();
            int result = 30;

            inputTriangleList.Add(new List<int>() { 7 });
            inputTriangleList.Add(new List<int>() { 3, 8 });
            inputTriangleList.Add(new List<int>() { 8, 1, 0 });
            inputTriangleList.Add(new List<int>() { 2, 7, 4, 4 });
            inputTriangleList.Add(new List<int>() { 4, 5, 2, 6, 5 });

            if(result == Solution(inputTriangleList))
            {
                Console.WriteLine("입력값에 따른 결과값이 일치");
            }
        }

        private int Solution(List<List<int>> triangleList)
        {
            return 0;
        }
    }
}