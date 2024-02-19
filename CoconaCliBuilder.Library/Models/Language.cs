namespace CoconaCliBuilder.Library.Models;

public class Language(string name, Dictionary<string, string> strings)
{
    public string Name { get; } = name;
    public Dictionary<string, string> Strings { get; } = strings;
}