public abstract class Logger : IHandler
{
    private IHandler succesor;

    public abstract void Handle(LogType logType, string message);

    public void SetSuccessor(IHandler succesor)
    {
        this.succesor = succesor;
    }

    protected void PassToSuccessor(LogType type, string message)
    {
        if (this.succesor != null)
        {
            this.succesor.Handle(type, message);
        }
    }
}
