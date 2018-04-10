using System;

public class DatabaseArray
{
    private const int Capacity = 16;

    private readonly int[] data;

    private int count;

    public DatabaseArray(params int[] inputIntegers)
    {
        this.data = new int[Capacity];
        if (this.data.Length != Capacity)
            throw new InvalidOperationException("Database must have a capacity of 16!");
        this.count = 0;

        foreach (var inputInteger in inputIntegers) this.Add(inputInteger);
    }

    public int Count => this.count;

    public void Add(int element)
    {
        if (this.count >= 16)
            throw new InvalidOperationException("Database is full!");

        this.data[this.count] = element;
        this.count++;
    }

    public int[] Fetch()
    {
        var arr = new int[this.count];
        for (var i = 0; i < this.count; i++) arr[i] = this.data[i];

        return arr;
    }

    public void Remove()
    {
        if (this.count == 0)
            throw new InvalidOperationException("Database is empty!");

        this.data[this.count - 1] = default(int);
        this.count--;
    }
}