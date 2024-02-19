using CoconaCliBuilder.Library.BusinessLogic;

namespace CoconaCliBuilder.Tests;

public class MockWriteService : IWriteService
{
    public bool Written { get; private set; }
    
    public void WriteLine(string text)
    {
        Written = true;
    }
}