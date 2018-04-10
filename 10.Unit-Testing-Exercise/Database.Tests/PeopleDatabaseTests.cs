namespace Database.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    class PeopleDatabaseTests
    {
        private const long firstId = 4321;

        private const string firstUsername = "Gosho";

        private const long secondId = 1234;

        private const string secondUsername = "Pesho";

        private const long testId = 0000;

        private const string testUsername = "Tosho";

        private PeopleDatabase db;

        [Test]
        public void AddMethodAddsPersonToDataBase()
        {
            // Act
            var person = new Person(testUsername, testId);
            this.db.Add(person);

            // Assert
            Assert.IsTrue(
                this.db[2].Id == testId && this.db[2].Username.Equals(testUsername),
                "Add method did not properly add person to the database!");
        }

        [Test]
        public void AddThrowsExceptionWhenDatabaseContainsGivenId()
        {
            // Act
            var person = new Person(testUsername, firstId);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.db.Add(person));
            Assert.AreEqual(
                "A person with the same ID already exists in the database!",
                ex.Message,
                "Database does not throw exception when a person with an existing ID is being added!");
        }

        [Test]
        public void AddThrowsExceptionWhenDatabaseContainsGivenUsername()
        {
            // Act
            var person = new Person(firstUsername, testId);

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.db.Add(person));
            Assert.AreEqual(
                "A person with the same username already exists in the database!",
                ex.Message,
                "Database does not throw exception when a person with an existing username is being added!");
        }

        [Test]
        public void ConstructorCreatesDatabaseProperly()
        {
            // Act
            this.db = new PeopleDatabase(new Person(testUsername, testId));

            // Assert
            var testPerson = this.db[0];
            Assert.IsTrue(
                testPerson.Id == testId && testPerson.Username.Equals(testUsername),
                "Constructor did not properly add person to the database!");
        }

        [Test]
        public void FindByIdFindsTheCorrectPerson()
        {
            // Act
            var person = this.db.FindById(firstId);

            // Assert
            Assert.IsTrue(
                person.Username.Equals(firstUsername) && person.Id == firstId,
                "FindById method does not return the correct person!");
        }

        [Test]
        public void FindByIdThrowsExceptionWhenArgumentIsNegative()
        {
            // Assert
            Assert.Catch<InvalidOperationException>(
                () => this.db.FindById(-1),
                "Database does not throw exception when the given ID is negative!");
        }

        [Test]
        public void FindByIdThrowsExceptionWhenIdIsNotFound()
        {
            // Assert
            Assert.Catch<InvalidOperationException>(
                () => this.db.FindById(testId),
                "Database does not throw exception when the given ID is not found!");
        }

        [Test]
        public void FindByUsernameFindsTheCorrectPerson()
        {
            // Act
            var person = this.db.FindByUserName(firstUsername);

            // Assert
            Assert.IsTrue(
                person.Username.Equals(firstUsername) && person.Id == firstId,
                "FindByUsername method does not return the correct person!");
        }

        [Test]
        public void FindByUsernameThrowsExceptionWhenArgumentIsNull()
        {
            // Assert
            Assert.Catch<ArgumentNullException>(
                () => this.db.FindByUserName(null),
                "Database does not throw exception when the given username is null!");
        }

        [Test]
        public void FindByUsernameThrowsExceptionWhenUsernameIsNotFound()
        {
            // Assert
            Assert.Catch<InvalidOperationException>(
                () => this.db.FindByUserName(testUsername),
                "Database does not throw exception when the given username is not found!");
        }

        [Test]
        public void RemoveMethodCorrectlyRemovesPersonFromDatabase()
        {
            // Act
            this.db.Remove();
            var lastPerson = this.db[0];

            // Assert
            Assert.IsTrue(
                lastPerson.Username.Equals(firstUsername) && lastPerson.Id == firstId,
                "Remove method does not properly remove the last person from the database!");
        }

        [Test]
        public void RemoveThrowsExceptionWhenDatabaseIsEmpty()
        {
            // Act
            this.db = new PeopleDatabase();

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => this.db.Remove());
            Assert.AreEqual(
                "Database is empty!",
                ex.Message,
                "Database does not throw exception when trying to remove a person when database is empty!");
        }

        [SetUp]
        public void TestInit()
        {
            // Arrange
            var person1 = new Person(firstUsername, firstId);
            var person2 = new Person(secondUsername, secondId);
            this.db = new PeopleDatabase(person1, person2);
        }
    }
}