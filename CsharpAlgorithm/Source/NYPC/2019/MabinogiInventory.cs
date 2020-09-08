using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 문제 링크 https://nypc.github.io/2019/2019_online_10.html
    /// </summary>
    class MabinogiInventory
    {
        private List<List<bool>> emptySlotList = new List<List<bool>>();

        private List<int> woolPosList = new List<int>();
        private List<int> woodPosList = new List<int>();

        private int woolCount = 0;
        private int woodCount = 0;

        private int height = 0;
        private int width = 0;

        public MabinogiInventory()
        {
            List<List<int>> itemInputList = new List<List<int>>();

            itemInputList.Add(new List<int>() { 5, 5, 4, 4 });
            itemInputList.Add(new List<int>() { 5, 5, 4, 4 });

            List<string> inventortInputList = new List<string>();

            inventortInputList.Add("XXXXXX---XX---XX---XXXXXX");
            inventortInputList.Add("XXXXXX--XXX--X-XXXX-XXXX-");

            List<List<int>> exampleResult = new List<List<int>>();

            exampleResult.Add(new List<int>() { 12, 0, 3, 2, 2, 2, 2, 3, 2, 4 });
            exampleResult.Add(new List<int>() { 8, 1, 1, 2, 2, 3, 5 });

            GetResulut(itemInputList[0], inventortInputList[0]);
            GetResulut(itemInputList[1], inventortInputList[1]);
        }

        private List<int> GetResulut(List<int> itemInputList, string inventoryInput)
        {
            List<int> resultList = new List<int>();

            int woolPrice = itemInputList[2];
            int woodPrice = itemInputList[3];

            emptySlotList = new List<List<bool>>();

            height = itemInputList[0];
            width = itemInputList[1];

            for (int i = 0; i < height; i++)
            {
                emptySlotList.Add(new List<bool>());
            }

            for (int i = 0; i < inventoryInput.Length; i++)
            {
                bool isEmpty = inventoryInput[i] == '-';

                emptySlotList[i / height].Add(isEmpty);
            }

            return resultList;
        }
    }
}
