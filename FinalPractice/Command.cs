namespace FinalPractice;

public abstract class Command
{
    public abstract Task RunAsync();
    public abstract bool Test(string url);
    public abstract void Cancel();
}