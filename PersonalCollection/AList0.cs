using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection
{
    public class AList0 : IList
    {
        int[] arr = { };

        public void Init(int[] ini)
        {
            if (ini == null)
            {
                arr = new int[0];
                return;
            }

            arr = new int[ini.Length];
            for (int i = 0; i < ini.Length; i++)
            {
                arr[i] = ini[i];
            }
        }

        public int Size()
        {
            return arr.Length;
        }

        public void Clear()
        {
            arr = new int[0];
        }

        public override String ToString()
        {
            string ret = "";
            for (int i = 0; i < arr.Length; i++)
            {
                ret += arr[i] + ((i != arr.Length - 1) ? ", " : "");
            }
            return ret;
        }

        public int[] ToArray()
        {
            int[] temp = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }
            return temp;
        }

        public void AddStart(int val)
        {
            int[] temp = new int[arr.Length + 1];
            temp[0] = val;
            for (int i = 1; i < temp.Length; i++)
            {
                temp[i] = arr[i - 1];
            }
            arr = temp;
        }

        public void AddEnd(int val)
        {
            int[] temp = new int[arr.Length + 1];
            temp[arr.Length] = val;
            for (int i = 0; i < arr.Length; i++)
            {
                temp[i] = arr[i];
            }
            arr = temp;
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > arr.Length)
                throw new IndexOutOfRangeException();

            int[] temp = new int[arr.Length + 1];
            for (int i = temp.Length - 1, j = i - 1; i >= 0; i--, j--)
            {
                if (i != pos)
                {
                    temp[i] = arr[j];
                }
                else
                {
                    temp[i] = val;
                    j++;
                }
            }
            arr = temp;
        }

        public int DelStart()
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();

            int ret = arr[0];
            int[] temp = new int[arr.Length - 1];
            for (int i = 1; i < arr.Length; i++)
            {
                temp[i - 1] = arr[i];
            }
            arr = temp;
            return ret;
        }
        public int DelEnd()
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();

            int ret = arr[arr.Length - 1];
            int[] temp = new int[arr.Length - 1];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = arr[i];
            }
            arr = temp;
            return ret;
        }
        public int DelPos(int pos)
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > arr.Length - 1)
                throw new IndexOutOfRangeException();

            int ret = arr[pos];
            int[] temp = new int[arr.Length - 1];
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < pos)
                {
                    temp[i] = arr[i];
                }
                else if (i > pos)
                {
                    temp[i - 1] = arr[i];
                }
            }
            arr = temp;
            return ret;
        }

        public int Min()
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();

            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        public int Max()
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();

            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        public int MinPos()
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();

            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < arr[res])
                {
                    res = i;
                }
            }
            return res;
        }

        public int MaxPos()
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();

            int res = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > arr[res])
                {
                    res = i;
                }
            }
            return res;
        }

        public void Set(int pos, int val)
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > arr.Length - 1)
                throw new IndexOutOfRangeException();

            arr[pos] = val;
        }
        public int Get(int pos)
        {
            if (arr.Length == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > arr.Length - 1)
                throw new IndexOutOfRangeException();

            return arr[pos];
        }

        public void Sort()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                int dummy = arr[i];
                arr[i] = arr[min];
                arr[min] = dummy;
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length - 1 - i];
                arr[arr.Length - 1 - i] = temp;
            }
        }
        public void HalfReverse()
        {
            int mid = (arr.Length % 2 == 0) ? arr.Length / 2 : arr.Length / 2 + 1;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[i + mid];
                arr[i + mid] = temp;
            }
        }
    }
}
