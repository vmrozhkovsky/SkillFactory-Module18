// See https://aka.ms/new-console-template for more information

// using YoutubeExplode;
// using YoutubeExplode.Converter;

// string outputFilePath = @"C:\Video\test";
// var youtubeclient = new YoutubeClient();
// var video = youtubeclient.Videos.GetAsync(videoUrl);
// Console.WriteLine($"Название: {video.Title}");
// Console.WriteLine($"Продолжительность: {video.Duration}");
// Console.WriteLine($"Автор: {video.Author}");

using FinalPractice;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Exceptions;

string videoUrl;

var sender = new Sender();

var receiver = new Receiver();
Console.WriteLine("Введите адрес видео:");
videoUrl = Console.ReadLine();

var isVideoExists = new IsVideoExists(receiver, videoUrl);
sender.SetCommand(isVideoExists);
while (sender.Test(videoUrl))
{
    videoUrl = Console.ReadLine();
}

var getVideoInfo = new GetVideoInfo(receiver, videoUrl);
sender.SetCommand(getVideoInfo);
await sender.Run();

var downloadVideo = new DownloadVideo(receiver, videoUrl);
sender.SetCommand(downloadVideo);
await sender.Run();


