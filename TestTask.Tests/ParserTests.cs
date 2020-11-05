using NUnit.Framework;
using System;

namespace TestTask.Tests
{
    public class ParserTests
    {
        [Test]
        public void CheckFirstTypeHandler()
        {
            var parser = new Parser(
                new string[] 
                { 
                    "1 200 56"
                });

            int result = parser.ParsedIntegers()[0];

            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CheckSecondTypeHandler()
        {
            var parser = new Parser(
                new string[]
                {
                    "2 256 1 1 1 1"
                });

            int result = parser.ParsedIntegers()[0];

            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CheckThirdTypeHandler()
        {
            var parser = new Parser(
                new string[]
                {
                    "3 200 56 34 234 -432"
                });

            int result = parser.ParsedIntegers()[0];

            //Assert
            Assert.AreEqual(234, result);
        }

        [Test]
        public void CheckFourthTypeHandler()
        {
            var parser = new Parser(
                new string[]
                {
                    "4 200 56 34 234 432"
                });

            int result = parser.ParsedIntegers()[0];

            //Assert
            Assert.AreEqual(34, result);
        }

        [Test]
        public void UnknownTypeHandler()
        {
            var parser = new Parser(
                new string[]
                {
                    "5 200 56 34 234 432"
                });

            //Assert
            Assert.Throws<Exception>(() => parser.ParsedIntegers());
        }

        [Test]
        public void NullLines_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(
                () => new Parser(null));
        }
    }
}