using System;
using System.Linq;
using System.Reflection;

using NUnit.Framework;

[TestFixture]
public class IteratorTests
{
    private const string firstString = "Pesho";

    private const string secondString = "Gosho";

    private ListIterator iterator;

    [Test]
    public void ConstructorThrowExceptionWhenParamatersAreNull()
    {
        // Assert
        Assert.Catch<ArgumentNullException>(
            () => this.iterator = new ListIterator(null),
            "Constructor should throw exception when parameters are null!");
    }

    [Test]
    public void MoveCorrectlyMovesIndex()
    {
        // Act
        this.iterator.Move();
        var index = typeof(ListIterator).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static)
            .FirstOrDefault(f => f.Name.Equals("index")).GetValue(this.iterator);

        // Assert
        Assert.AreEqual(1, index, "Move has not moved the index to the correct value!");
    }

    [Test]
    public void MoveCorrectlyReturnsFalseWhenFalse()
    {
        // Act
        this.iterator.Move();

        // Assert
        Assert.IsFalse(this.iterator.Move(), "Move should return false!");
    }

    [Test]
    public void MoveCorrectlyReturnsTrueWhenTrue()
    {
        // Assert
        Assert.IsTrue(this.iterator.Move(), "Move should return true!");
    }

    [Test]
    public void PrintPrintsTheCorrectElement()
    {
        // Assert
        Assert.AreEqual(firstString, this.iterator.Print(), "Print does not return the correct element!");
    }

    [Test]
    public void PrintThrowsExceptionWhenCollectionIsEmpty()
    {
        // Act
        this.iterator = new ListIterator();

        // Assert
        Assert.Catch<InvalidOperationException>(
            () => this.iterator.Print(),
            "Print should throw exception when collection is empty!");
    }

    [SetUp]
    public void TestInit()
    {
        // Arrange
        this.iterator = new ListIterator(firstString, secondString);
    }
}