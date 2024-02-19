namespace CoconaCliBuilder.Library.BusinessLogic;

public class WriteService : IWriteService
{
    public void Write(string text)
    { 
        Console.WriteLine(text);
    }
}