namespace FinalPractice;

// Класс Sender для отправки команд
public class Sender
{
    Command _command;
  
    public void SetCommand(Command command)
    {
        _command = command;
    }
    
    public async Task Run()
    {
       await _command.RunAsync();
    }
  
    public bool Test(string url)
    {
       return _command.Test(url);
    }
    
    public void Cancel()
    {
        _command.Cancel();
    }
}