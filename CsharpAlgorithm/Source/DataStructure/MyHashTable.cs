using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class HashNode<T, T2>
    {
        public HashNode<T, T2> next = null;

        public T key;
        public T2 value;

        public HashNode(T key, T2 value)
        {
            this.key = key;
            this.value = value;
        }
    }

    class MyHashTable<T, T2>
    {
        private HashNode<T, T2>[] bucketArr = null;

        //resize시 사용할 배열 이전 배열의 크기 2배 이상으로
        private int[] primeNumberArr = { 3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239, 293, 353, 431, 521, 631, 761, 919,
    1103, 1327, 1597, 1931, 2333, 2801, 3371, 4049, 4861, 5839, 7013, 8419, 10103, 12143, 14591,
    17519, 21023, 25229, 30293, 36353, 43627, 52361, 62851, 75431, 90523, 108631, 130363, 156437,
    187751, 225307, 270371, 324449, 389357, 467237, 560689, 672827, 807403, 968897, 1162687, 1395263,
    1674319, 2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369 };

        private int capacity = 3;

        public int Count { get; private set; } = 0;

        public MyHashTable(int capacity = 3)
        {
            this.capacity = capacity;
            bucketArr = new HashNode<T, T2>[capacity];
        }

        public void Add(T key, T2 value)
        {
            if(IsContainsKey(key))
            {
                throw new Exception("키가 중복되었습니다.");
            }

            if(IsFull())
            {
                Resize();
            }

            int index = GetHashIndex(key);

            HashNode<T, T2> newNode = new HashNode<T, T2>(key, value);
            HashNode<T, T2> curNode = bucketArr[index];

            if(curNode == null)
            {
                bucketArr[index] = newNode;
            }
            else
            {
                while (curNode.next != null)
                {
                    curNode = curNode.next;
                }

                curNode.next = newNode;
            }

            Count++;
        }

        public void Remove(T key)
        {
            int index = GetHashIndex(key);

            HashNode<T, T2> curNode = bucketArr[index];

            if (curNode == null)
            {
                throw new Exception("해당하는 키에 대한 데이터가 없습니다.");
            }
            else
            {
                if(curNode.key.Equals(key))
                {
                    bucketArr[index] = bucketArr[index].next;

                    Count--;
                }
                else
                {
                    HashNode<T, T2> prevNode = null;

                    while (curNode != null)
                    {
                        if (curNode.key.Equals(key))
                        {
                            prevNode.next = curNode.next;
                            Count--;

                            return;
                        }
                        else
                        {
                            prevNode = curNode;
                            curNode = curNode.next;
                        }
                    }
                }
            }
        }

        public bool IsContainsKey(T key)
        {
            int index = GetHashIndex(key);

            HashNode<T, T2> curNode = bucketArr[index];

            while (curNode != null)
            {
                if(curNode.key.Equals(key))
                {
                    return true;
                }

                curNode = curNode.next;
            }

            return false;
        }

        public bool IsContainsValue(T2 value)
        {
            for (int i = 0; i < capacity; i++)
            {
                HashNode<T, T2> curNode = bucketArr[i];

                while (curNode != null)
                {
                    if (curNode.value.Equals(value))
                    {
                        return true;
                    }

                    curNode = curNode.next;
                }
            }

            return false;
        }

        private int GetHashIndex(T key)
        {
            return  Math.Abs(key.GetHashCode() % capacity);
        }

        private bool IsFull()
        {
            if(Count >= capacity)
            {
                return true;
            }

            return false;
        }

        private void Resize()
        {
            if(capacity >= primeNumberArr[primeNumberArr.Length -1])
            {
                return;
            }

            for (int i = 0; i < primeNumberArr.Length; i++)
            {
                if((capacity * 2) <= primeNumberArr[i])
                {
                    capacity = primeNumberArr[i];
                    break;
                }
            }

            MyHashTable<T, T2> newHashTable = new MyHashTable<T, T2>(capacity);

            for (int i = 0; i < bucketArr.Length; i++)
            {
                HashNode<T, T2> tempNode = bucketArr[i];

                while (tempNode != null)
                {
                    newHashTable.Add(tempNode.key, tempNode.value);
                    tempNode = tempNode.next;
                }
            }

            bucketArr = newHashTable.bucketArr;
        }
    }
}
