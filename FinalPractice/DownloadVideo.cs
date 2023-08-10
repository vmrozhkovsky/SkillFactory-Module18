namespace FinalPractice;
// Класс команды для загрузки видео
public class DownloadVideo : Command
{
    private Receiver _receiver;
    private string _videoUrl;
    private string _pathToDownloadDir;

    public DownloadVideo(Receiver receiver, string videoUrl, string pathToDownloadDir)
    {
        this._receiver = receiver;
        this._videoUrl = videoUrl;
        this._pathToDownloadDir = pathToDownloadDir;
    }

    public async override Task RunAsync()
    {
        await _receiver.DownloadVideo(_videoUrl, _pathToDownloadDir);
    }

    public override bool Test(string url)
    {
        return true;
    }
    public override void Cancel()
    {}
}