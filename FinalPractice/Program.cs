// See https://aka.ms/new-console-template for more information

using YoutubeExplode;
using YoutubeExplode.Converter;
Console.WriteLine("Введите адрес видео:");
string videoUrl = Console.ReadLine();
string outputFilePath = @"C:\Video\test";
var youtubeclient = new YoutubeClient();
var video = await youtubeclient.Videos.GetAsync(videoUrl);
Console.WriteLine($"Название: {video.Title}");
Console.WriteLine($"Продолжительность: {video.Duration}");
Console.WriteLine($"Автор: {video.Author}");