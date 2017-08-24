using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTests
{
    [TestClass]
    public class TestAList1Add : AddingTests
    {
        internal override IListMemory MakeList()
        {
            return new AList1();
        }
    }

    [TestClass]
    public class TestAList2Add : AddingTests
    {
        internal override IListMemory MakeList()
        {
            return new AList2();
        }
    }
    [TestClass]
    public abstract class AddingTests
    {
        internal abstract IListMemory MakeList();
        IListMemory li_obj;
        public AddingTests()
        {
            li_obj = MakeList();
        }


        [DataTestMethod]
        [DataRow(30)]
        [DataRow(40)]
        [DataRow(50)]
        public void TestInitOverflow(int n)
        {
            int[] arr = new int[n];
            int[] expected = new int[n];
            for (int i = 0; i < n; ++i)
            {
                arr[i] = i;
                expected[i] = i;
            }
            li_obj.Init(arr);
            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }

        [DataTestMethod]
        [DataRow(20, 10)]
        [DataRow(20, 20)]
        [DataRow(20, 30)]
        public void TestAddOverflow(int ini_n, int add)
        {
            int[] arr = new int[ini_n];
            int[] expected = new int[ini_n + add];

            for (int i = 0; i < ini_n; ++i)
            {
                arr[i] = i;
                expected[i] = i;
            }

            li_obj.Init(arr);

            for (int i = ini_n; i < ini_n + add; ++i)
            {
                expected[i] = i;
                li_obj.AddEnd(i);
            }

            CollectionAssert.AreEqual(expected, li_obj.ToArray());
        }
    }
}
