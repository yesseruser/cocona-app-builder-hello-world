using CoconaCliBuilder.Library.BusinessLogic;
using CoconaCliBuilder.Library.Models;

namespace CoconaCliBuilder.Tests;

[TestClass]
public class BusinessLogicTests
{
    [TestMethod]
    public void Localizer_DefaultLanguageName()
    {
        var localizer = new Localizer();
        var actual = localizer.GetDefaultLanguageName();
        
        Assert.AreEqual("en", actual);
    }

    [TestMethod]
    public void Localizer_LocalizedString()
    {
        var localizer = new Localizer();
        var actual = localizer.GetLocalizedString(StringKeys.Hello, "en",
            (_, _, _) => "");
        
        Assert.AreEqual("Hello, World!", actual);
    }

    [TestMethod]
    public void Localizer_LocalizedString_WithException()
    {
        var localizer = new Localizer();
        var actual = localizer.GetLocalizedString("", "en",
            (_, _, e) =>
            {
                Assert.IsNotNull(e);
                return "";
            });
        
        Assert.AreEqual("", actual);
    }

    [TestMethod]
    public void LanguageByName_NonExistentLanguageName()
    {
        var localizer = new Localizer();

        Assert.ThrowsException<ArgumentNullException>(() => localizer.GetLanguageByName("foobar_nonexistent_language"));
    }

    [TestMethod]
    public void CurrentLanguage()
    {
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var expected = currentCulture.TwoLetterISOLanguageName;
        
        var localizer = new Localizer();
        var actual = localizer.GetCurrentLanguageName();
        
        Assert.AreEqual(expected, actual);
    }
}