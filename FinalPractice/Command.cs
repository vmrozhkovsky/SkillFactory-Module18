namespace FinalPractice;
// Абстрактный родительский класс для команд
public abstract class Command
{
    // Метод для асинхронного запуска команды
    public abstract Task RunAsync();
    // Метод для тестирования
    public abstract bool Test(string url);
    // Метод для отмены
    public abstract void Cancel();
}