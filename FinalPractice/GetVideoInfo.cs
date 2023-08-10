namespace FinalPractice;

// Класс команды для получения информации о видео
public class GetVideoInfo : Command
{
    private Receiver _receiver;
    private string _videoUrl;

    public GetVideoInfo(Receiver receiver, string videoUrl)
    {
        this._receiver = receiver;
        this._videoUrl = videoUrl;
    }

    public override async Task RunAsync()
    {
        await _receiver.GetVideoInfo(_videoUrl);
    }

    public override bool Test(string url)
    {
        return true;
    }
    public override void Cancel()
    {}
}