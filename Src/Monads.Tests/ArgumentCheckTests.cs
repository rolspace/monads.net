using NUnit.Framework;

namespace System.Monads.Tests
{
    [TestFixture]
    public class ArgumentCheckTests
    {
        [Test]
        public void CheckNullArgNameSuccess()
        {
            string source = "Some value";
            var result = source.CheckNull("source");

            Assert.AreEqual(source, result);
        }

        [Test]
        public void CheckNullArgNameFail()
        {
            string source = null;
            try
            {
                var result = source.CheckNull("source");

                Assert.Fail("CheckNull should throw ArgumentNullException");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("source", ex.ParamName);
            }
        }

        [Test]
        public void CheckNullArgLambdaSuccess()
        {
            string source = "Some value";
            var result = source.CheckNull(() => new IndexOutOfRangeException("paramName"));

            Assert.AreEqual(source, result);
        }

        [Test]
        public void CheckNullArgLambdaFail()
        {
            string source = null;
            try
            {
                var result = source.CheckNull(() => new IndexOutOfRangeException("Exception message"));

                Assert.Fail("CheckNull should throw IndexOutOfRangeException");
            }
            catch (IndexOutOfRangeException ex)
            {
                Assert.AreEqual("Exception message", ex.Message);
            }
        }

        [Test]
        public void CheckNullDefaultValueSuccess()
        {
            string source = "Some value";
            var result = source.CheckNull("Error");

            Assert.AreEqual(source, result);
        }

        [Test]
        public void CheckNullDefaultValueFail()
        {
            string source = null;
            var result = source.CheckNullWithDefault("Error");

            Assert.AreEqual("Error", result);
        }

        [Test]
        public void CheckWithExceptionSuccess()
        {
            var source = 10;
            var result = source.Check(s => s > 5, s => new ArgumentException("Param should be greater than 5."));
            Assert.AreEqual(source, result);
        }

        [Test]
        public void CheckWithExceptionFail()
        {
            var source = 3;

            try
            {
                var result = source.Check(s => s > 5, s => new ArgumentException("Param should be greater than 5."));

                Assert.Fail("Check should throw ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Param should be greater than 5.", ex.Message);
            }
        }

        [Test]
        public void CheckWithDefaultValueSuccess()
        {
            var source = 10;
            var result = source.CheckWithDefault(s => s > 5, int.MinValue);
            Assert.AreEqual(source, result);
        }

        [Test]
        public void CheckWithDefaultValueFail()
        {
            var source = 3;
            var result = source.CheckWithDefault(s => s > 5, int.MinValue);
            Assert.AreEqual(int.MinValue, result);
        }
    }
}