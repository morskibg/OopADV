public class KillEventArgs
{
    public KillEventArgs(Soldier soldier, King kingDefended)
    {
        this.Soldier = soldier;
        this.KingDefended = kingDefended;
    }

    public King KingDefended { get; }

    public Soldier Soldier { get; }
}