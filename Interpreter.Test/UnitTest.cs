using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interpreter.Core;

namespace Interpreter.Test
{
    [TestClass]
    public class UnitTest
    {
        public YandexTranslator YandexTranslator;

        public UnitTest()
        {
            YandexTranslator = new YandexTranslator("supported_languages.json", "config.json")
            {
                //here comes your api-key
                ApiKey = "" 
            };
        }

        [TestMethod]
        public void TestMethod_DetermineLanguage()
        {            
            Assert.AreEqual(new Language {Code = "ru", Name = "Русский"}, YandexTranslator.DetermineLanguage("Привет, мир!"));
            try
            {
                YandexTranslator.DetermineLanguage(" ");
                Assert.Fail();
            }
            catch (LanguageTranslateException) { }
        }

        [TestMethod]
        public void TestMethod_TranslateText()
        {
            Assert.AreEqual("Hello world!", YandexTranslator.TranslateText("Привет мир!", "ru", "en"));
            Assert.AreEqual("Всем привет!", YandexTranslator.TranslateText("Hello world!", "en", "ru"));
            try
            {
                YandexTranslator.TranslateText(" ", "ru", "en");
                Assert.Fail();
            }
            catch (LanguageTranslateException) { }
        }
    }
}
