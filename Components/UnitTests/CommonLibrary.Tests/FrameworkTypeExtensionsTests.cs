using System.Collections.Generic;
using NUnit.Framework;
using Samples.Finder.Components.Common.CommonLibrary.Extensions;
using System.Linq;

namespace Samples.Finder.Components.Common.CommonLibrary.Tests
{
    [TestFixture]
    public class FrameworkTypeExtensionsTests
    {
        private class A
        {
            public List<A> Childs { get; set; }

            public A()
            {
                Childs = new List<A>();
            }
        }

        [Test]
        public void SelectRecursivelyTest()
        {
            var root = new A();
            var element1 = new A();
            var element2 = new A();
            root.Childs.Add(element1);
            root.Childs.Add(element2);
            var subElement = new A();
            element2.Childs.Add(subElement);
            var descendants = root.Childs.SelectRecursively(x => x.Childs).ToList();
            Assert.AreEqual(3, descendants.Count);
            Assert.AreEqual(element1, descendants[0]);
            Assert.AreEqual(element2, descendants[1]);
            Assert.AreEqual(subElement, descendants[2]);
        }
    }
}