using System.Text.Json;
using CoconaCliBuilder.Library.Models;

namespace CoconaCliBuilder.Library.BusinessLogic;

public class Localiser
{
    public string GetLocalizedString(string key, string languageName)
    {
        var language = GetLanguageByName(languageName);
        return language.Strings.First(x => x == key);
    }

    public string GetCurrentLanguageName()
    {
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        return currentCulture.TwoLetterISOLanguageName;
    }

    private Language GetLanguageByName(string languageName)
    {
        var serializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        
        var languages = JsonSerializer.Deserialize<Language[]>(
            File.ReadAllText("strings.json"), serializerOptions
        );
        if (languages is null)
            throw new ArgumentNullException("Unable to find localization table.");

        var language = languages.First(x => x.LanguageName == languageName);
        if (language is null)
            throw new ArgumentNullException("Language was not found in the localization table.");

        return language;
    }
}