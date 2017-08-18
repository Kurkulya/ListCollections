using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection
{
    public class AList1 : IList
    {
        int[] arr = new int[10];
        int top = 0;

        public void Init(int[] ini)
        {
            if (ini == null)
            {
                arr = new int[10];
                top = 0;
                return;
            }

            for (int i = 0; i < ini.Length; i++)
            {
                arr[i] = ini[i];
            }
            top = ini.Length;
        }

        public int Size()
        {
            return top;
        }

        public void Clear()
        {
            arr = new int[10];
            top = 0;
        }

        public override String ToString()
        {
            string ret = "";
            for (int i = 0; i < top; i++)
            {
                ret += arr[i] + ((i != top - 1) ? ", " : "");
            }
            return ret;
        }

        public int[] ToArray()
        {
            int[] temp = new int[top];
            for (int i = 0; i < top; i++)
            {
                temp[i] = arr[i];
            }
            return temp;
        }

        public void AddStart(int val)
        {
            for (int i = top; i != 0; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[0] = val;
            top++;
        }

        public void AddEnd(int val)
        {
            arr[top] = val;
            top++;
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > top)
                throw new IndexOutOfRangeException();

            top++;
            for (int i = top - 1, j = i - 1; i >= 0; i--, j--)
            {
                if (i != pos)
                {
                    arr[i] = arr[j];
                }
                else
                {
                    arr[i] = val;
                    j++;
                }
            }
        }

        public int DelStart()
        {
            if (top == 0)
                throw new EmptyArrayEx();

            int ret = arr[0];
            top--;
            for (int i = 0; i < top; i++)
            {
                arr[i] = arr[i + 1];
            }
            return ret;
        }
        public int DelEnd()
        {
            if (top == 0)
                throw new EmptyArrayEx();

            top--;
            return arr[top];
        }
        public int DelPos(int pos)
        {
            if (top == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > top - 1)
                throw new IndexOutOfRangeException();

            int ret = arr[pos];
            top--;
            for (int i = pos; i < top; i++)
            {
                arr[i] = arr[i + 1];
            }
            return ret;
        }

        public int Min()
        {
            if (top == 0)
                throw new EmptyArrayEx();

            int min = arr[0];
            for (int i = 1; i < top; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        public int Max()
        {
            if (top == 0)
                throw new EmptyArrayEx();

            int max = arr[0];
            for (int i = 1; i <top; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }
        public int MinPos()
        {
            if (top == 0)
                throw new EmptyArrayEx();

            int res = 0;
            int min = arr[0];
            for (int i = 0; i < top; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                    res = i;
                }
            }
            return res;
        }

        public int MaxPos()
        {
            if (top == 0)
                throw new EmptyArrayEx();

            int res = 0;
            int max = arr[0];
            for (int i = 0; i < top; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    res = i;
                }
            }
            return res;

        }

        public void Set(int pos, int val)
        {
            if (top == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > top - 1)
                throw new IndexOutOfRangeException();

            arr[pos] = val;
        }
        public int Get(int pos)
        {
            if (top == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > top - 1)
                throw new IndexOutOfRangeException();

            return arr[pos];
        }

        public void Sort()
        {
            int step = top / 2;
            while (step > 0)
            {
                int j;
                for (int i = step; i < top; i++)
                {
                    int value = arr[i];
                    for (j = i - step; (j >= 0) && (arr[j] > value); j -= step)
                    {
                        arr[j + step] = arr[j];

                    }
                    arr[j + step] = value;
                }
                step /= 2;
            }
        }
        public void Reverse()
        {

            for (int i = 0; i < top / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[top - 1 - i];
                arr[top - 1 - i] = temp;
            }
        }
        public void HalfReverse()
        {
            for (int j = 0; j < top / 2; j++)
            {
                int temp = arr[0];
                for (int i = 0; i < top - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[top - 1] = temp;
            }
        }
    }
}
