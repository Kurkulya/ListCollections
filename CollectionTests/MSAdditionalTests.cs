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
    public class TestAList1Add : MSAddingTests
    {
        internal override IList MakeList()
        {
            return new AList1();
        }
    }

    [TestClass]
    public class TestAList2Add : MSAddingTests
    {
        internal override IList MakeList()
        {
            return new AList2();
        }
    }
    [TestClass]
    public abstract class MSAddingTests
    {
        internal abstract IList MakeList();
        IList lst;
        public MSAddingTests()
        {
            lst = MakeList();
        }

        [TestInitialize]
        public void SetUp()
        {
            lst.Clear();
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
            lst.Init(arr);
            CollectionAssert.AreEqual(expected, lst.ToArray());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12,13,14,15,11 })]
        public void TestAddEndOverflow(int[] ini, int[] exp)
        {

            lst.Init(ini);
            lst.AddEnd(11);

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] {11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,}, new int[] { 11, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] {11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})]
        public void TestAddStartOverflow(int[] ini, int[] exp)
        {

            lst.Init(ini);
            lst.AddStart(11);

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 11, 6, 7, 8, 9, 10 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 11, 6, 7, 8, 9 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 1, 2, 3, 4, 5, 11, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void TestAddPosOverflow(int[] ini, int[] exp)
        {

            lst.Init(ini);
            lst.AddPos(5, 11);

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }
    }
}
