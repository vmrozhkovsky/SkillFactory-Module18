namespace FinalPractice;

public class DownloadVideo : Command
{
    private Receiver _receiver;
    private string _videoUrl;

    public DownloadVideo(Receiver receiver, string videoUrl)
    {
        this._receiver = receiver;
        this._videoUrl = videoUrl;
    }

    public async override Task RunAsync()
    {
        await _receiver.DownloadVideo(_videoUrl);
    }

    public override bool Test(string url)
    {
        return true;
    }
    public override void Cancel()
    {}
}