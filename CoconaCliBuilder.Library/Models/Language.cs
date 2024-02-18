namespace CoconaCliBuilder.Library.Models;

public abstract record Language(string LanguageName, List<string> Strings)
{
    public string LanguageName { get; set; } = LanguageName;
    public List<string> Strings { get; set; } = Strings;
}