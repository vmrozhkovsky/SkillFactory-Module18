namespace FinalPractice;

// Класс команды для тестирования ссылок на видео
public class IsVideoExists : Command
{
    private Receiver _receiver;
    private string _videoUrl;

    public IsVideoExists(Receiver receiver, string videoUrl)
    {
        this._receiver = receiver;
        this._videoUrl = videoUrl;
    }

    public override bool Test(string url)
    {
       return _receiver.IsVideoExists(url);
    }
    
    public override async Task RunAsync()
    {}
    
    public override void Cancel()
    {}
}