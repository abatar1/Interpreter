using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Interpreter.Core
{
    public sealed class YandexTranslator
    {
        

        public YandexTranslator(string supportedLanguagesFilename, string configFilename)
        {
            _supportedLanguagesFilename = supportedLanguagesFilename;
            _configFilename = configFilename;      
        }

        public Language DetermineLanguage(string text)
        {
            var urlText = Uri.EscapeUriString(text);
            var query = $"{ServiceUrl}/detect?key={ApiKey}&text={urlText}";
            var rawJson = GetStringFromQuery(query);
            var langCode = JObject.Parse(rawJson)["lang"].ToString();
            var langName = SupportedLanguages[langCode];
            return new Language {Code = langCode, Name = langName};
        }

        public string TranslateText(string text, string fromCode, string toCode)
        {
            var urlText = Uri.EscapeUriString(text);
            var translationDir = $"{fromCode}-{toCode}";
            var query = $"{ServiceUrl}/translate?key={ApiKey}&text={urlText}&lang={translationDir}";
            var rawJson = GetStringFromQuery(query);

            var returnCode = int.Parse(JObject.Parse(rawJson)["code"].ToString());
            switch (returnCode)
            {
                case 413:
                    throw new LanguageTranslateException("Превышен максимально допустимый размер текста");
                case 422:
                    throw new LanguageTranslateException("Текст не может быть переведен");
                case 501:
                    throw new LanguageTranslateException("Заданное направление перевода не поддерживается");
                case 404:
                    throw new LanguageTranslateException("Превышено суточное ограничение на объем переведенного текста");
                case 200:
                    return JObject.Parse(rawJson)["text"][0].ToString();
            }

            return null;
        }

        private static string GetStringFromQuery(string query)
        {
            var request = WebRequest.Create(query);
            var response = (HttpWebResponse)request.GetResponse();
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        private void OnEmptyConfig(EventArgs e)
        {
            EmptyConfig?.Invoke(this, e);
        }

        private readonly string _supportedLanguagesFilename;
        private readonly string _configFilename;

        private const string ServiceUrl = "https://translate.yandex.net/api/v1.5/tr.json/";

        private IDictionary<string, string> _supportedLanguages;
        public IDictionary<string, string> SupportedLanguages
        {
            get
            {
                if (_supportedLanguages != null) return _supportedLanguages;

                if (!File.Exists(_supportedLanguagesFilename))
                {
                    var query = $"{ServiceUrl}getLangs?ui=ru&key={ApiKey}";
                    var rawJson = GetStringFromQuery(query);
                    var json = JObject.Parse(rawJson)["langs"].ToString();
                    File.WriteAllText(_supportedLanguagesFilename, json, Encoding.Default);
                }

                var languagesSerialized = File.ReadAllText(_supportedLanguagesFilename, Encoding.Default);
                _supportedLanguages = JsonConvert.DeserializeObject<IDictionary<string, string>>(languagesSerialized);

                return _supportedLanguages;
            }
        }

        private string _apiKey;
        public string ApiKey
        {
            get
            {
                if (_apiKey != null) return _apiKey;

                if (!File.Exists(_configFilename))
                {
                    OnEmptyConfig(new EventArgs());
                    var jObject = new JObject {{"api_key", _apiKey}};
                    File.WriteAllText(_configFilename, jObject.ToString(), Encoding.Default);
                }

                var configSerialized = File.ReadAllText(_configFilename, Encoding.Default);
                var configObject = JObject.Parse(configSerialized);
                _apiKey = (string)configObject["api_key"];

                return _apiKey;
            }
            set => _apiKey = value;
        }

        public event EventHandler EmptyConfig;
    }
}