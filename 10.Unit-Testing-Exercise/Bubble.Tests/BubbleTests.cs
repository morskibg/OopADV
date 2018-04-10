namespace Bubble.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class BubbleTests
    {
        private int[] numbers;

        [Test]
        public void SortsNumbersCorrectly()
        {
            // Arrange
            this.numbers = new[] { 3, 1, 2 };
            var expeceted = new[] { 1, 2, 3 };

            //Act
            BubbleSorter.Sort(this.numbers);

            //Assert
            Assert.AreEqual(expeceted, this.numbers, "Numbers were not sorted correctly!");
        }

        [Test]
        public void SortsNumbersCorretlyWithNegativeValues()
        {
            //Arrange
            this.numbers = new[] { -1, -3, -2 };
            var expected = new[] { -3, -2, -1 };

            //Act
            BubbleSorter.Sort(this.numbers);
            
            //Assert
            Assert.AreEqual(expected, this.numbers, "Numbers were not sorted correctly!");
        }
    }
}