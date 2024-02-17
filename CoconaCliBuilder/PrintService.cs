namespace CoconaCliBuilder;

public class PrintService : IPrintService
{
    public void Print(string text)
    { 
        Console.WriteLine(text);
    }
}