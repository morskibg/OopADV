namespace Database.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;

    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private const int expectedCapacity = 16;

        private DatabaseArray db;

        private Type type;

        [Test]
        public void AddElementWithFullArrayThrowsException()
        {
            // Act
            this.db = new DatabaseArray(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.db.Add(17));
            Assert.AreEqual(
                "Database is full!",
                ex.Message,
                "Database should throw exception when trying to add more than 16 elements!");
        }

        [Test]
        public void DatabaseHasCapacityOf16()
        {
            // Act
            var capacity = this.type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name.Equals("Capacity")).GetValue(this.db);

            // Assert
            Assert.AreEqual(expectedCapacity, capacity, "Capacity must be exactly 16!");
        }

        [Test]
        public void FetchMethodShouldReturnAllElementsAsAnArray()
        {
            // Act
            var elements = this.db.Fetch();

            // Assert
            Assert.AreEqual(new[] { 1 }, elements, "Database does not return its elements as an array!");
        }

        [Test]
        public void RemoveElementFromEmptyArrayThrowsException()
        {
            // Act
            this.db.Remove();

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.db.Remove());
            Assert.AreEqual(
                "Database is empty!",
                ex.Message,
                "Trying to remove an element from an empty array should throw exception!");
        }

        [SetUp]
        public void TestInit()
        {
            // Arrange
            this.type = typeof(DatabaseArray);
            this.db = new DatabaseArray(1);
        }
    }
}