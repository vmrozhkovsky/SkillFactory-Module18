using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Exceptions;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace FinalPractice;

public class Receiver
{
    private YoutubeClient _youtubeClient = new YoutubeClient();
    public bool IsVideoExists(string videoUrl)
    {
        try
        {
            var isVideo = _youtubeClient.Videos.GetAsync(videoUrl);
            return false;
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Ссылка неверна. Видео не существует! Пожалуйста, введите правильную ссылку:");
            return true;
        }
    }
    public async Task GetVideoInfo(string videoUrl)
    {
        var videoInfo = await _youtubeClient.Videos.GetAsync(videoUrl);
        Console.WriteLine($"Название: {videoInfo.Title}");
        Console.WriteLine($"Продолжительность: {videoInfo.Duration}");
        Console.WriteLine($"Описание: {videoInfo.Description}");
    }

    public async Task DownloadVideo(string videoUrl)
    {
        try
        {
            // await _youtubeClient.Videos.DownloadAsync(videoUrl, @"C:\video\test\video.mp4");
            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            await _youtubeClient.Videos.Streams.DownloadAsync(streamInfo, @"C:\video\test\video.mp4");
        }
        catch (VideoUnavailableException)
        {
            Console.WriteLine("Видео не доступно!");
        }
    }
}

