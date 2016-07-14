using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalLINQ.Library;

namespace PracticalLINQ.Tests
{
    [TestClass]
    public class BuilderTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void BuildIntegerSequenceTest()
        {
            var listBuilder = new Builder();

            var result = listBuilder.BuildIntegerSequence();

            foreach (var item in result)
            {
                TestContext.WriteLine(item.ToString());
            }

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuildStringSequenceTest()
        {
            var listBuilder = new Builder();

            var result = listBuilder.BuildStringSequence();

            foreach (var item in result)
            {
                TestContext.WriteLine(item);
            }

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CompareSequenceTest()
        {
            var listBuilder = new Builder();
            var result = listBuilder.CompareSequences();

            foreach (var item in result)
                TestContext.WriteLine(item.ToString());

            Assert.IsNotNull(result);
        }

    }
}
