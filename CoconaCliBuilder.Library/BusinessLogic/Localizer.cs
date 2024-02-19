using Newtonsoft.Json;
using CoconaCliBuilder.Library.Models;

namespace CoconaCliBuilder.Library.BusinessLogic;

public class Localizer : ILocalizer
{
    public string GetLocalizedString(string key, string languageName)
    {
        var language = GetLanguageByName(languageName);
        return language.Strings.First(x => x.Key == key).Value;
    }

    public string GetLocalizedString(string key, string languageName, Func<string, string, Exception, string> onException)
    {
        try
        {
            return GetLocalizedString(key, languageName);
        }
        catch (Exception e)
        {
            return onException(key, languageName, e);
        }
    }

    public string GetCurrentLanguageName()
    {
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        return currentCulture.TwoLetterISOLanguageName;
    }

    public string GetDefaultLanguageName()
    {
        var languages = JsonConvert.DeserializeObject<Language[]>(
            File.ReadAllText("strings.json")
        );
        if (languages is null || languages.Length <= 0)
            throw new ArgumentNullException("Unable to find localization table, or it's empty.");
        
        return languages.First().Name;
    }

    public Language GetLanguageByName(string languageName)
    {
        var languages = JsonConvert.DeserializeObject<List<Language>>(
            File.ReadAllText("strings.json")
        );
        if (languages is null)
            throw new ArgumentNullException("Unable to find localization table.");

        Language? language;
        try
        {
            language = languages.First(x => x.Name == languageName);
        }
        catch
        {
            language = null;
        }
        
        if (language is null)
            throw new ArgumentNullException("Language was not found in the localization table.");

        return language;
    }
}