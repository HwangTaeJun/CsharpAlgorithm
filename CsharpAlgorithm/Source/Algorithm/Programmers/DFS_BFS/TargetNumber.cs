using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class TargetNumberInput
    {
        public int[] numberArr = null;
        public int target = 0;

        public TargetNumberInput(int[] numberArr, int target)
        {
            this.numberArr = numberArr;
            this.target = target;
        }
    }

    /// <summary>
    /// 타겟 넘버 https://programmers.co.kr/learn/courses/30/lessons/43165
    /// </summary>
    class TargetNumber
    {
        private int[] inputDataArr = null;
        private int target = 0;
        private int answer = 0;
        private int sumNumber = 0;

        public TargetNumber()
        {
            List<TargetNumberInput> inputList = new List<TargetNumberInput>();
            inputList.Add(new TargetNumberInput(new int[] { 1, 1, 1, 1, 1 }, 3));

            for (int i = 0; i < inputList.Count; i++)
            {
                Solution(inputList[i].numberArr, inputList[i].target);
            }
        }

        public int Solution(int[] numbers, int target)
        {
            answer = 0;
            this.target = target;
            inputDataArr = numbers;

            for (int i = 0; i < numbers.Length; i++)
            {
                sumNumber += numbers[i];
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                CreateCombination(i + 1, new int[i + 1], 0, 0);
            }

            Console.WriteLine("TargetNumber Answer " + answer);

            return answer;
        }
       
        private void CreateCombination(int pickCount, int[] tempResultArr, int current, int start)
        {

            if (pickCount == current)
            {
                string num = null;
                int subNum = 0;

                for (int i = 0; i < tempResultArr.Length; i++)
                {
                    num += tempResultArr[i].ToString();

                    subNum -= tempResultArr[i];
                }

                int calcNum = (sumNumber + (subNum * 2));

                if (calcNum == target)
                {
                    for (int i = 0; i < tempResultArr.Length; i++)
                    {
                        Console.Write(tempResultArr[i]);
                    }

                    Console.Write(", ");

                    answer++;
                }
            }
            else
            {
                for (int i = start; i < inputDataArr.Length; i++)
                {
                    tempResultArr[current] = inputDataArr[i];
                    CreateCombination(pickCount, tempResultArr, current + 1, i + 1);
                }
            }
        }
    }
}
