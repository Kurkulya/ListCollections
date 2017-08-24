using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection
{
    public class LList2 : IList
    {
        class Node
        {
            public int val;
            public Node next = null;
            public Node prev = null;
            public Node(int val)
            {
                this.val = val;
            }
        }

        Node start = null;
        Node end = null;

        private Node GetNode(int pos)
        {
            Node p = start;
            for(int i = 0; i< pos;i++)
            {
                p = p.next;
            }
            return p;
        }

        public void AddEnd(int val)
        {
            if (Size() == 0)
            {
                AddStart(val);
            }
            else
            {
                Node newNode = new Node(val);
                end.next = newNode;
                newNode.prev = end;
                end = newNode;
            }
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > Size())
                throw new IndexOutOfRangeException();

            if (pos == 0)
            {
                AddStart(val);
            }
            else if (pos == Size())
            {
                AddEnd(val);
            }
            else
            {
                Node cur = GetNode(pos - 1);
                Node newNode = new Node(val);
                cur.next.prev = newNode;
                newNode.next = cur.next;
                cur.next = newNode;
                newNode.prev = cur;
            }

        }

        public void AddStart(int val)
        {
            if (Size() == 0)
            {
                Node temp = new Node(val);
                start = temp;
                end = temp;
            }
            else
            {
                Node temp = new Node(val);
                temp.next = start;
                start.prev = temp;
                start = temp;
            }
        }

        public void Clear()
        {
            start = null;
            end = null;
        }

        public int DelEnd()
        {
            if (Size() == 0)
                throw new EmptyArrayEx();

            int ret = 0;

            if (Size() == 1)
            {
                ret = DelStart();
                return ret;
            }
            else
            {                
                ret = end.val;
                end = end.prev;
                end.next = null;
                
            }
            return ret;
        }

        public int DelPos(int pos)
        {
            if (Size() == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > Size() - 1)
                throw new IndexOutOfRangeException();

            int ret = 0;
            if (pos == 0)
            {
                ret = DelStart();
            }
            else if (pos == Size() - 1)
            {
                ret = DelEnd();
            }
            else
            {
                Node cur = GetNode(pos - 1);
                ret = cur.next.val;
                cur.next.next.prev = cur;
                cur.next = cur.next.next;
            }
            return ret;
        }

        public int DelStart()
        {
            if (Size() == 0)
                throw new EmptyArrayEx();

            int ret = start.val;

            if (Size() != 1)
            {
                start.next.prev = null;
                start = start.next;
            }
            else
            {
                Clear();
            }

            return ret;
        }

        public int Get(int pos)
        {
            if (Size() == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > Size() - 1)
                throw new IndexOutOfRangeException();

            return GetNode(pos).val;
        }

        public void HalfReverse()
        {
            if (Size() == 1 || Size() == 0)
                return;

            Node newEnd = GetNode(Size() / 2 - 1);
            Node newStart = GetNode(Size() / 2 );
            start.prev = end;
            end.next = start;            
            newEnd.next = null;
            newStart.prev = null;
            end = newEnd;
            start = newStart;
        }

        public void Init(int[] ini)
        {
            if (ini == null)
                ini = new int[0];

            for (int i = ini.Length - 1; i >= 0; i--)
            {
                AddStart(ini[i]);
            }
        }

        public int Max()
        {
            if (Size() == 0)
                throw new EmptyArrayEx();

            int max = start.val;
            Node cur = start;
            for (int i = 0; cur.next != null; i++)
            {
                cur = cur.next;
                if (cur.val > max)
                    max = cur.val;
            }
            return max;
        }

        public int MaxPos()
        {
            if (Size() == 0)
                throw new EmptyArrayEx();

            int ret = 0;
            Node cur = start;
            while (cur.next != null)
            {
                if (cur.val == Max())
                    break;
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public int Min()
        {
            if (Size() == 0)
                throw new EmptyArrayEx();

            int min = start.val;
            Node cur = start;
            for (int i = 0; cur.next != null; i++)
            {
                cur = cur.next;
                if (cur.val < min)
                    min = cur.val;
            }
            return min;
        }

        public int MinPos()
        {
            if (Size() == 0)
                throw new EmptyArrayEx();

            int ret = 0;
            Node cur = start;
            while (cur.next != null)
            {
                if (cur.val == Min())
                    break;
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public void Reverse()
        {
            if (Size() == 1 || Size() == 0)
                return;

            Node cur = start;
            while(cur != null)
            {
                Node tempCur = cur.next;
                cur.next = cur.prev;
                cur.prev = tempCur;
                cur = cur.prev;
            }

            Node temp = end;
            end = start;
            start = temp;
        }

        public void Set(int pos, int val)
        {
            if (Size() == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > Size() - 1)
                throw new IndexOutOfRangeException();

            GetNode(pos).val = val;       
        }

        public int Size()
        {
            if (start == null || end == null)
                return 0;

            int ret = 1;
            Node cur = start;
            while (cur.next != null)
            {
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public void Sort()
        {
            for (int i = 0; i < Size() - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < Size(); j++)
                {
                    if (Get(j) < Get(min))
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    int temp = Get(i);
                    Set(i, Get(min));
                    Set(min, temp);
                }
            }
        }

        public int[] ToArray()
        {
            int[] temp = new int[Size()];
            for (int i = 0; i < Size(); i++)
            {
                temp[i] = Get(i);
            }
            return temp;
        }

        public override String ToString()
        {
            string ret = "";
            for (int i = 0; i < Size(); i++)
            {
                ret += Get(i) + ((i != Size() - 1) ? ", " : "");
            }
            return ret;
        }
    }
}
