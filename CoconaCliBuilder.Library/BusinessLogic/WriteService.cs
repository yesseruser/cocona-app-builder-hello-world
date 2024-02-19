namespace CoconaCliBuilder.Library.BusinessLogic;

public class WriteService : IWriteService
{
    public void WriteLine(string text)
    { 
        Console.WriteLine(text);
    }
}