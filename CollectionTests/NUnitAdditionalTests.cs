using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Compatibility;
using PersonalCollection;

namespace CollectionTests
{
    [TestFixture(typeof(AList1))]
    [TestFixture(typeof(AList2))]
    public class NUnitAddingTests<TPage>where TPage : IList, new()
    {
        IList lst = new TPage();

        [SetUp]
        public void SetUp()
        {
            lst.Clear();
        }


        [Test]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(50)]
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

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9,}, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 11 })]
        public void TestAddEndOverflow(int[] ini, int[] exp)
        {

            lst.Init(ini);
            lst.AddEnd(11);

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9}, new int[] { 11, 1, 2, 3, 4, 5, 6, 7, 8, 9})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void TestAddStartOverflow(int[] ini, int[] exp)
        {

            lst.Init(ini);
            lst.AddStart(11);

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 11, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9}, new int[] { 1, 2, 3, 4, 5, 11, 6, 7, 8, 9})]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, new int[] { 1, 2, 3, 4, 5, 11, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void TestAddPosOverflow(int[] ini, int[] exp)
        {

            lst.Init(ini);
            lst.AddPos(5, 11);

            CollectionAssert.AreEqual(exp, lst.ToArray());
        }
    }
}
