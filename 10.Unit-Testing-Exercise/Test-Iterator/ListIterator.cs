using System;
using System.Collections;
using System.Collections.Generic;

public class ListIterator
{
    private const int INITIAL_INDEX = 0;

    private readonly IList collection;

    private int count;

    private int index;

    public ListIterator(params string[] inputStrings)
    {
        if (inputStrings == null)
            throw new ArgumentNullException("Input cannot be null!");
        this.collection = new List<string>(inputStrings);
        this.count = inputStrings.Length;
        this.index = INITIAL_INDEX;
    }

    public bool Move()
    {
        if (!this.HasNext())
            return false;
        this.index++;
        return true;
    }

    public bool HasNext()
    {
        if (this.index == this.count - 1)
            return false;
        return true;
    }

    public string Print()
    {
        if(this.count == 0)
            throw new InvalidOperationException("Invalid operation!");

        return this.collection[this.index].ToString();
    }
}