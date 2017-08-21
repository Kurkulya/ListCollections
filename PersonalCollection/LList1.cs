using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection
{
    public class LList1 : IList
    {
        class Node
        {
            public int val;
            public Node next = null;
            public Node(int val)
            {
                this.val = val;
            }
        }

        Node root = null;

        public void AddEnd(int val)
        {
            if (Size() == 0)
            {
                AddStart(val);
            }
            else
            {
                Node cur = root;
                while (cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = new Node(val);
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
                Node cur = root;
                for (int i = 0; i < pos - 1; i++)
                {
                    cur = cur.next;
                }
                Node newNode = new Node(val);
                newNode.next = cur.next;
                cur.next = newNode;
            }

        }

        public void AddStart(int val)
        {
            Node temp = new Node(val);
            temp.next = root;
            root = temp;
        }

        public void Clear()
        {
            root = null;
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
                Node cur = root;
                while (cur.next.next != null)
                {
                    cur = cur.next;
                }
                ret = cur.next.val;
                cur.next = null;
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
                Node cur = root;
                for (int i = 0; i != pos - 1; i++)
                {
                    cur = cur.next;
                }
                ret = cur.next.val;
                cur.next = cur.next.next;
            }
            return ret;
        }

        public int DelStart()
        {
            if (Size() == 0)
                throw new EmptyArrayEx();


            int ret = root.val;

            if (Size() != 1)
                root = root.next;
            else
                root = null;

            return ret;
        }

        public int Get(int pos)
        {
            if (Size() == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > Size() - 1)
                throw new IndexOutOfRangeException();

            Node cur = root;
            for (int i = 0; i != pos; i++)
            {
                cur = cur.next;
            }
            return cur.val;
        }

        public void HalfReverse()
        {
            if (Size() == 1 || Size() == 0)
                return;

            Node cur = root;
            while (cur.next != null)
            {
                cur = cur.next;
            }
            Node mid = root;
            for (int i = 0; i < Size() / 2 - 1; i++)
            {
                mid = mid.next;
            }
            cur.next = root;
            root = mid.next;
            mid.next = null;
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

            int max = root.val;
            Node cur = root;
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
            Node cur = root;
            while(cur.next != null)
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

            int min = root.val;
            Node cur = root;
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
            Node cur = root;
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

            Node end = root;
            while (end.next != null)
            {
                end = end.next;
            }
            Node newRoot = end;
            while (end != root)
            {
                Node cur = root;
                while (cur.next != end)
                {
                    cur = cur.next;
                }
                end.next = cur;
                end = cur;
            }
            root.next = null;
            root = newRoot;
        }

        public void Set(int pos, int val)
        {
            if (Size() == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > Size() - 1)
                throw new IndexOutOfRangeException();

            Node cur = root;
            for (int i = 0; i != pos; i++)
            {
                cur = cur.next;
            }
            cur.val = val;
        }

        public int Size()
        {
            if (root == null)
                return 0;

            int ret = 1;
            Node cur = root;
            while (cur.next != null)
            {
                ret++;
                cur = cur.next;
            }
            return ret;
        }

        public void Sort()
        {
            for (int i = 0; i < Size() -1; i++)
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
