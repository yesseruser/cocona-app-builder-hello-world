using CoconaCliBuilder.Library.BusinessLogic;

namespace CoconaCliBuilder.Tests;

public class MockWriteService : IWriteService
{
    public bool Written { get; private set; }
    
    public void Write(string text)
    {
        Written = true;
    }
}