using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCollection
{
    public class AList2 : IList
    {
        int[] arr = new int[10];
        int start = 5;
        int end = 5;

        public void AddEnd(int val)
        {
            if (end == arr.Length && start != 0)
                ShiftToLeft();
            else if (Size() == arr.Length)
                ExtendArray(arr.Length);

            arr[end++] = val;
        }

        public void AddPos(int pos, int val)
        {
            if (pos < 0 || pos > end - start)
                throw new IndexOutOfRangeException();

            if (end == arr.Length && start != 0)
                ShiftToLeft();
            else if(Size() == arr.Length)
                ExtendArray(arr.Length);

            for (int i = end++ - 1; i >= pos + start; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[start + pos] = val;
        }

        public void AddStart(int val)
        {
            if (start == 0 && end != arr.Length)
                ShiftToRight();
            else if(Size() == arr.Length)
                ExtendArray(arr.Length);

            arr[--start] = val;
        }

        public void Clear()
        {
            start = 5;
            end = 5;
            arr = new int[10];
        }

        public int DelEnd()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            return arr[--end];
        }

        public int DelPos(int pos)
        {
            if (end - start == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > (end - start) - 1)
                throw new IndexOutOfRangeException();

            int ret = arr[start + pos];
            end--;
            for (int i = start + pos; i < end; i++)
            {
                arr[i] = arr[i + 1];
            }

            return ret;
        }

        public int DelStart()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            return arr[start++];
        }

        private void ExtendArray(int size)
        {
            int new_size = (int)(size * 1.3);
            int[] temp = new int[new_size];
            if (start == end)
            {
                start = new_size / 2;
                end = new_size / 2;
            }
            else if(start == 0 && end == arr.Length)
            {
                int nStart = temp.Length / 2 - Size() / 2;
                int nEnd = nStart + Size();
                for (int i = start, j = nStart; i < end; i++, j++)
                {
                    temp[j] = arr[i];
                }
                start = nStart;
                end = nEnd;                
            }
            arr = temp;
        }

        private void ShiftToRight()
        {
            start++;
            for (int i = ++end; i > start; i++)
            {
                arr[i] = arr[i - 1];
            }
        }

        private void ShiftToLeft()
        {
            end--;
            for (int i = --start; i < end; i++)
            {
                arr[i] = arr[i + 1];
            }
        }

        public int Get(int pos)
        {
            if (end - start == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > (end - start) - 1)
                throw new IndexOutOfRangeException();

            return arr[pos + start];
        }

        public void HalfReverse()
        {
            int mid = (Size() % 2 == 0) ? Size() / 2 : Size() / 2 + 1;
            for (int i = start; i < start + Size() / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[i + mid];
                arr[i + mid] = temp;
            }
        }

        public void Init(int[] ini)
        {
            if(ini == null)
            {
                start = 5;
                end = 5;
                return;
            }

            if (ini.Length > arr.Length)
                ExtendArray(ini.Length);

            start -= ini.Length / 2;
            end += ini.Length - (ini.Length / 2);
            for (int i = start; i < end; i++)
            {
                arr[i] = ini[i - start];
            }
        }

        public int Max()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            int max = arr[start];
            for (int i = start + 1; i < end; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        public int MaxPos()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            int res = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i] > arr[res])
                {
                    res = i;
                }
            }
            return res - start;
        }

        public int Min()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            int min = arr[start];
            for (int i = start + 1; i < end; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }

        public int MinPos()
        {
            if (end - start == 0)
                throw new EmptyArrayEx();

            int res = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i] < arr[res])
                {
                    res = i;
                }
            }
            return res - start;
        }

        public void Reverse()
        {
            for (int i = start; i < start + Size() / 2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[end - 1 - (i - start)];
                arr[end - 1 - (i - start)] = temp;
            }
        }

        public void Set(int pos, int val)
        {
            if (end - start == 0)
                throw new EmptyArrayEx();
            if (pos < 0 || pos > (end - start) - 1)
                throw new IndexOutOfRangeException();

            arr[pos + start] = val;
        }

        public int Size()
        {
            return end - start;
        }

        public void Sort()
        {
            for (int i = start; i < end - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < end; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }

        public int[] ToArray()
        {
            int[] temp = new int[end - start];
            for (int i = start; i < end; i++)
            {
                temp[i-start] = arr[i];
            }
            return temp;
        }

        public override String ToString()
        {
            string ret = "";
            for (int i = start; i < end; i++)
            {
                ret += arr[i] + ((i != end - 1) ? ", " : "");
            }
            return ret;
        }
    }
}
