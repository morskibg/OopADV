public class Person
{
    private long id;

    private string username;

    public Person(string username, long id)
    {
        this.Username = username;
        this.Id = id;
    }

    public long Id
    {
        get => this.id;
        set => this.id = value;
    }

    public string Username
    {
        get => this.username;
        set => this.username = value;
    }
}