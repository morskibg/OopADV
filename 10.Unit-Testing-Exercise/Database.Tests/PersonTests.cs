namespace Database.Tests
{
    using System.Collections.Generic;

    using NUnit.Framework;

    [TestFixture]
    class PersonTests
    {
        private const string username = "Pesho";

        private const long id = 1234;

        [Test]
        public void ConstructorCreatesProperPerson()
        {
            // Act
            Person person = new Person(username, id);

            // Assert
            Assert.IsTrue(person.Id == id && person.Username.Equals(username), "Constructor does not create the person with proper values!");
        }
    }
}