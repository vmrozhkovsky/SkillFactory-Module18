using FinalPractice;

string VideoUrl;
string PathToDonwloadDir = null;
string UserСhoice = null;
bool UserChoiceCorrect = true;

// Инициализация класса Sender. Считывание данных о необходимом пользователю функционале с проверкой правильности ввода.
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

// Инициализация класса Receiver. Считывание данных о видео с проверкой его существования.
var receiver = new Receiver();
Console.WriteLine("Введите адрес видео:");
VideoUrl = Console.ReadLine();
var isVideoExists = new IsVideoExists(receiver, VideoUrl);
sender.SetCommand(isVideoExists);
while (sender.Test(VideoUrl))
{
    VideoUrl = Console.ReadLine();
}
// Инициализация классов команд в зависимости от выбора пользователя.
switch (UserСhoice)
{
    // Передача команды на получение информации о видео
    case "1":
        var getVideoInfo = new GetVideoInfo(receiver, VideoUrl);
        sender.SetCommand(getVideoInfo);
        await sender.Run();
        break;
    // Передача команды на загрузку видео с запросом на путь для загрузки и проверкой правильности ввода.
    case "2":
        if (!File.Exists(Environment.CurrentDirectory + @"\ffmpeg.exe"))
        {
            Console.WriteLine("Файл ffmpeg.exe, необходимый для загрузки должен находиться в папке с программой. Загрузите его и попробуйте снова.");
            Console.ReadLine();
            Environment.Exit(0);
        }
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


