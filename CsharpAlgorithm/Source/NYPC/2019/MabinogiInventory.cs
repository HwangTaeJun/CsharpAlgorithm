using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.NYPC._2019
{
    /// <summary>
    /// 문제 링크 https://nypc.github.io/2019/2019_online_10.html
    /// </summary>
    class MabinogiInventory
    {
        private List<List<bool>> emptySlotList = new List<List<bool>>();

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
        }

        private List<int> GetResulut(List<int> itemInputList, string inventoryInput)
        {
            List<int> resultList = new List<int>();

            int height = itemInputList[0];
            int width = itemInputList[1];
            
            int woolPrice = itemInputList[2];
            int woodPrice = itemInputList[3];
            
            int woolCount = 0;
            int woodCoubnt = 0;

            for (int i = 0; i < height; i++)
            {
                emptySlotList.Add(new List<bool>());
            }

            for (int i = 0; i < inventoryInput.Length; i++)
            {
                bool isEmpty = inventoryInput[i] == '-';

                emptySlotList[i % height].Add(isEmpty);
            }

            return resultList;

        }

        private void GetItemCount()
        {
            for (int i = 0; i < emptySlotList.Count; i++)
            {
                for (int j = 0; j < emptySlotList[i].Count; j++)
                {

                }
            }
        }

        private bool IsFillItem(bool isWool, int x, int y)
        {
            if(isWool)
            {
                if(emptySlotList[y][x + 1] && emptySlotList[y + 1][x] && emptySlotList[y + 1][x + 1])
                {
                    emptySlotList[y][x + 1] = emptySlotList[y + 1][x] = emptySlotList[y + 1][x + 1] = false;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (emptySlotList[y][x] && emptySlotList[y + 1][x] && emptySlotList[y + 2][x])
                {
                    emptySlotList[y][x] = emptySlotList[y + 1][x] = emptySlotList[y + 2][x] = false;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
