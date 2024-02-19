namespace CoconaCliBuilder.Library.Models;

public class Language(string name, Dictionary<string, string> strings)
{
    public string Name { get; set; } = name;
    public Dictionary<string, string> Strings { get; set; } = strings;
}