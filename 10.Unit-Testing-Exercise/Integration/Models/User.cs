using System.Collections.Generic;

public class User : IUser
{
    private HashSet<ICategory> categories;

    private string name;

    public User(string name)
    {
        this.name = name;
        this.categories = new HashSet<ICategory>();
    }

    public IEnumerable<ICategory> Categories => this.categories;

    public string Name => this.name;

    public void AddCategory(ICategory category)
    {
        this.categories.Add(category);
    }

    public void RemoveCategory(ICategory category)
    {
        this.categories.RemoveWhere(c => c.Name == category.Name);

        if (category.Parent != null) this.categories.Add(category.Parent);
    }
}