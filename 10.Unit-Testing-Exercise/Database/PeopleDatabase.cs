using System;
using System.Collections.Generic;
using System.Linq;

public class PeopleDatabase
{
    private readonly IList<Person> storage;

    private int count;

    public PeopleDatabase(params Person[] people)
    {
        this.storage = new List<Person>(people);
        this.count = people.Length;
    }

    public int Count => this.count;

    public Person this[int i] => this.storage[i];

    public void Add(Person person)
    {
        if (this.storage.Any(p => p.Id.Equals(person.Id)))
            throw new InvalidOperationException("A person with the same ID already exists in the database!");

        if (this.storage.Any(p => p.Username.Equals(person.Username)))
            throw new InvalidOperationException("A person with the same username already exists in the database!");

        this.storage.Add(person);
        this.count++;
    }

    public Person FindById(long id)
    {
        if (!this.storage.Any(p => p.Id == id))
            throw new InvalidOperationException("No person with the given ID present in the database!");

        if (id < 0)
            throw new ArgumentOutOfRangeException("ID must not be negative!");

        return this.storage.FirstOrDefault(p => p.Id == id);
    }

    public Person FindByUserName(string username)
    {

        if (username == null)
            throw new ArgumentNullException("Username is null!");

        if (!this.storage.Any(p => p.Username.Equals(username)))
            throw new InvalidOperationException("No person with the given username present in the database!");

        return this.storage.FirstOrDefault(p => p.Username.Equals(username));
    }

    public void Remove()
    {
        if (this.count == 0)
            throw new InvalidOperationException("Database is empty!");

        this.storage.Remove(this.storage.Last());
        this.count--;
    }
}