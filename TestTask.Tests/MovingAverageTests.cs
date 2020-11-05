using NUnit.Framework;
using System;

namespace TestTask.Tests
{
    public class MovingAverageTests
    {
        [Test]
        public void IncorrectWindow_EvenWindow_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentException>(()=> new MovingAverage(new int[] { 0 }, 4));
        }

        [Test]
        public void IncorrectWindow_WindowBelowRange_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new MovingAverage(new int[] { 0 }, 2));
        }

        [Test]
        public void IncorrectWindow_WindowAboveRange_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentException>(() => new MovingAverage(new int[] { 0 }, 1000002));
        }

        [Test]
        public void CorrectWindow_DoesntThrowsException()
        {
            //Assert
            Assert.DoesNotThrow(() => new MovingAverage(new int[] { 0 }, 3));
            Assert.DoesNotThrow(() => new MovingAverage(new int[] { 0 }, 1000001));
        }

        [Test]
        public void NullInput_ThrowsException()
        {
            //Assert
            Assert.Throws<ArgumentNullException>(
                () => new MovingAverage(null, 5));
        }

        [Test]
        public void MovingAverage_AlgorithmTest()
        {
            double[] expected = new double[]
            {
                2.00,
                3.33,
                3.40,
                4.60,
                5.00,
                4.80,
                4.80,
                5.60,
                4.33,
                10.00 
            };

            var avg = new MovingAverage(
                new int[]
                {
                    2, 5, 3, 1, 6, 8, 7, 2, 1, 10
                },
                5);

            //Assert
            double[] actual = avg.Smooth();
            for (int i = 0; i < actual.Length; i++)
            {
                actual[i] = Math.Round(actual[i], 2);
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
