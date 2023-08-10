using FinalPractice;

string VideoUrl;
string PathToDonwloadDir = null;
string UserСhoice = null;
bool UserChoiceCorrect = true;

var sender = new Sender();
while (UserChoiceCorrect)
{
    Console.WriteLine("Выберите необходимое действие:\n" +
                      "1 - Получить информацию о видео.\n" +
                      "2 - Загрузить видео на диск.");
    UserСhoice = Console.ReadLine();
    if (UserСhoice == "1" || UserСhoice == "2")
    {
        UserChoiceCorrect = false;
    }
    else
    {
        Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
    }
}

var receiver = new Receiver();
Console.WriteLine("Введите адрес видео:");
VideoUrl = Console.ReadLine();

var isVideoExists = new IsVideoExists(receiver, VideoUrl);
sender.SetCommand(isVideoExists);
while (sender.Test(VideoUrl))
{
    VideoUrl = Console.ReadLine();
}
switch (UserСhoice)
{
    case "1":
        var getVideoInfo = new GetVideoInfo(receiver, VideoUrl);
        sender.SetCommand(getVideoInfo);
        await sender.Run();
        break;
    case "2":
        UserChoiceCorrect = true;
        while (UserChoiceCorrect)
        {
            Console.WriteLine("Введите адрес папки для загрузки:");
            PathToDonwloadDir = Console.ReadLine();
            if (!PathToDonwloadDir.EndsWith(@"\"))
            {
                PathToDonwloadDir = PathToDonwloadDir + @"\";
            }
            DirectoryInfo InitialDir = new DirectoryInfo(PathToDonwloadDir);
            if (InitialDir.Exists)
            {
                UserChoiceCorrect = false;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
            }
        }

        var downloadVideo = new DownloadVideo(receiver, VideoUrl, PathToDonwloadDir);
        sender.SetCommand(downloadVideo);
        await sender.Run();
        break;
}


