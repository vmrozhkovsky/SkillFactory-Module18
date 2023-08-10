using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Exceptions;

namespace FinalPractice;

// Класс Receiver для выполнения команд
public class Receiver
{
    private YoutubeClient _youtubeClient = new YoutubeClient();
    
    // Метод для тестирования ссылок на видео. Получает ссылку. Возвращает bool в зависимости от результата тестирования. 
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
    
    // Метод для получения информации о видео. Получает проверенную ссылку.
    public async Task GetVideoInfo(string videoUrl)
    {
        var videoInfo = await _youtubeClient.Videos.GetAsync(videoUrl);
        Console.WriteLine($"Название: {videoInfo.Title}");
        Console.WriteLine($"Продолжительность: {videoInfo.Duration}");
        Console.WriteLine($"Описание: {videoInfo.Description}");
    }

    // Метод для загрузки видео с обработкой ошибок. Получает проверенную ссылку и проверенный путь для загрузки.
    public async Task DownloadVideo(string videoUrl, string pathToDownloadDir)
    {
        try
        {
            Console.WriteLine("Начинаем загружать видео...");
            var progress = new Progress<double>();
            progress.ProgressChanged += (s,e) => Console.WriteLine($"Загружено: {e:P2}");
            var videoInfo = await _youtubeClient.Videos.GetAsync(videoUrl);
            string filePath = pathToDownloadDir + videoInfo.Title + ".mp4";
            await _youtubeClient.Videos.DownloadAsync(
                videoUrl, 
                filePath,
            o => o.SetPreset(ConversionPreset.UltraFast).SetFFmpegPath(Environment.CurrentDirectory + @"\ffmpeg.exe"),
                progress
                );
            Console.WriteLine($"Видео успешно загружено в файл {filePath}.");
        }
        catch (VideoUnavailableException)
        {
            Console.WriteLine("Видео не доступно!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Возникла непредвиденная ошибка {ex.Message}!");
        }
    }
}

