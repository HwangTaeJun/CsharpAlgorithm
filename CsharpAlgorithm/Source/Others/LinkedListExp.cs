using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class Node
    {
        public Node nextNode = null;
        public int data = 0;
    }

    class LinkedListExp
    {
        Node head = null;

        public void AppendNode(int data)
        {
            Node newNode = new Node();

            newNode.data = data;
            newNode.nextNode = null;

            if(head == null)
            {
                head = newNode;
            }
            else
            {
                Node tail = head;

                while (tail.nextNode != null)
                {
                    tail = tail.nextNode;
                }

                tail.nextNode = newNode;
            }
        }

        public void RemoveNode(ref Node head, Node remove)
        {
            if (head == remove)
            {
                head = remove.nextNode;
            }
            else
            {
                Node current = head;

                while (current.nextNode != remove)
                {
                    current = current.nextNode;
                }

                if (current != null)
                {
                    current.nextNode = remove.nextNode;
                }
            }
        }
    }
}
