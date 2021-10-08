using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.SingleLinkList
{
    class Node
    {
        public int info;
        public Node link;

        public Node(int i)
        {
            info = i;
            link = null;
        }
    }

    public class SingleLinkList
    {
        private Node start;
        private readonly IOutput output;

        public SingleLinkList(IOutput consoleIO)
        {
            start = null;
            output = consoleIO;
        }

        public void InsertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.link = start;
            start = temp;
        }

        public void InsertAtEnd(int data)
        {
            Node p;
            Node temp = new Node(data);

            if (start == null)
            {
                start = temp;
                return;
            }

            p = start;
            while (p.link != null)
            {
                p = p.link;
            }
            p.link = temp;
        }

        public void InsertAfter(int data, int x)
        {
            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                    break;
                p = p.link;
            }

            if (p == null)
            {
                output.WriteLine(x + "not present in the list.");
            }
            else
            {
                Node temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void InsertBefore(int data, int x)
        {
            Node temp;

            if (start == null)
            {
                output.WriteLine("List is empty");
                return;
            }

            if (x == start.info)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }


            Node p = start;
            while (p.link != null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }

            if (p.link == null)
                output.WriteLine(x + "not present in list");
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void DeleteFirstNode()
        {
            if (start == null)
                return;
            start = start.link;
        }

        public void DeleteLastNode()
        {
            if (start == null)
            {
                return;
            }

            if (start.link == null)
            {
                start = null;
                return;
            }

            Node p = start;
            while (p.link.link != null)
            {
                p = p.link;
            }
            p.link = null;
        }

        public void DeleteNode(int x)
        {
            if (start == null)
                output.WriteLine("List is empty");

            if (start.info == x)
            {
                start = start.link;
                return;
            }

            Node p = start;
            while (p.link != null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }

            if (p.link == null)
                output.WriteLine("Element " + x + " not found");
            else
                p.link = p.link.link;
        }

        public void ReverseList()
        {
            Node prev, p, next;
            prev = null;
            p = start;
            while (p != null)
            {
                next = p.link;
                p.link = prev;
                prev = p;
                p = next;
            }
            start = prev;
        }

        public void BubbleSortExData()
        {
            Node p, q, end;

            for (end = null; end != start.link; end = p)
            {
                for (p = start; p.link != end; p = p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        int temp = p.info;
                        p.info = q.info;
                        q.info = temp;
                    }
                }
            }
        }

        public void BubbleSortExLinks()
        {
            Node end, r, p, q, temp;

            for (end = null; end != start.link; end = p)
            {
                for (r = p = start; p.link != end; r = p, p = p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        p.link = q.link;
                        q.link = p;
                        if (p != start)
                            r.link = q;
                        else
                            start = q;
                        temp = p;
                        p = q;
                        q = temp;
                    }
                }
            }
        }

        public SingleLinkList Merge1(SingleLinkList list)
        {
            SingleLinkList mergeList = new SingleLinkList(output);
            mergeList.start = Merge1(start, list.start);
            return mergeList;
        }

        private Node Merge1(Node p1, Node p2)
        {
            Node startM;

            if (p1.info <= p2.info)
            {
                startM = new Node(p1.info);
                p1 = p1.link;
            }
            else
            {
                startM = new Node(p2.info);
                p2 = p2.link;
            }

            Node pM = startM;

            while (p1 != null && p2 != null)
            {
                if (p1.info < p2.info)
                {
                    pM.link = new Node(p1.info);
                    p1 = p1.link;
                }
                else
                {
                    pM.link = new Node(p2.info);
                    p2 = p2.link;
                }
                pM = pM.link;
            }

            return startM;
        }

        public void DisplayList()
        {
            Node p;
            if (start == null)
            {
                output.WriteLine("List is empty");
            }

            p = start;
            while (p != null)
            {
                output.WriteLine(p.info + " ");
                p = p.link;
            }
            Console.WriteLine();
        }

        public void CountNodes()
        {
            int n = 0;
            Node p = start;
            while (p != null)
            {
                n++;
                p = p.link;
            }
            output.WriteLine("Number of nodes is : " + n);
        }

        public bool Search(int x)
        {
            int position = 1;
            Node p = start;
            while (p != null)
            {
                if (p.info == x)
                {
                    break;
                }
                position++;
                p = p.link;
            }

            if (p == null)
            {
                output.WriteLine("not found");
                return false;
            }
            else
            {
                //ConsoleIO.WriteLine("{1} is at postion: {2}", x, position);
                return true;
            }
        }
    }
}
