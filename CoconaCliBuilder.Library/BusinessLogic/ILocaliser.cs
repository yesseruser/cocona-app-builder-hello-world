using CoconaCliBuilder.Library.Models;

namespace CoconaCliBuilder.Library.BusinessLogic;

public interface ILocaliser
{
    string GetLocalizedString(string key, string languageName);
    string GetLocalizedString(string key, string languageName, Func<string, string, Exception, string> onException);
    string GetCurrentLanguageName();
    string GetDefaultLanguageName();
    Language GetLanguageByName(string languageName);
}