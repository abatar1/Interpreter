using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Interpreter.Core;

namespace Interpreter.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            YandexTranslator = new YandexTranslator("supported_languages.json", "config.json");
            YandexTranslator.EmptyConfig += PopupFormInvoked;

            var supportedLanguages = YandexTranslator.SupportedLanguages;

            InitializeLanguageListControl(inputLanguageComboBox, languages: supportedLanguages, displayMember: "Value", valueMember: "Key");
            InitializeLanguageListControl(outputLanguageComboBox, languages: supportedLanguages, displayMember: "Value", valueMember: "Key");
        }

        private static void InitializeLanguageListControl(ListControl comboBox, IDictionary<string, string> languages, string displayMember, string valueMember)
        {
            comboBox.DataSource = new BindingSource(languages, null);
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedIndex = -1;
        }

        private string SetComboBoxSelectedItem(ListControl comboBox, Control textBox)
        {
            var lang = new Language();
            try
            {
                lang = YandexTranslator.DetermineLanguage(textBox.Text);
            }
            catch (LanguageTranslateException ex)
            {
                messageLabel.Text = ex.Message;
            }
            catch (ApiTranslateException ex)
            {
                messageLabel.Text = ex.Message;
                CreatePopupForm();
            }

            comboBox.SelectedIndex = inputLanguageComboBox.FindString(lang.Name);
            return lang.Code;
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            if (outputLanguageComboBox.SelectedItem == null)
            {
                messageLabel.Text = "Пожалуйста, выберите язык перевода.";
            }
            else
            {
                messageLabel.Text = "";

                string fromLang;
                if (inputLanguageComboBox.SelectedItem == null)
                {
                    fromLang = SetComboBoxSelectedItem(inputLanguageComboBox, translateInputTextBox);
                }
                else
                {
                    dynamic fromLangItem = inputLanguageComboBox.SelectedItem;
                    fromLang = fromLangItem.Key;
                }

                dynamic toLangItem = outputLanguageComboBox.SelectedItem;
                var toLang = toLangItem.Key;

                try
                {
                    var translatedText = YandexTranslator.TranslateText(translateInputTextBox.Text, fromLang, toLang);
                    translateOutputTextBox.Text = translatedText.Replace("\n", "\r\n");
                }
                catch (LanguageTranslateException ex)
                {
                    messageLabel.Text = ex.Message;
                }
                catch (ApiTranslateException ex)
                {
                    messageLabel.Text = ex.Message;
                    CreatePopupForm();
                }
            }            
        }

        private void determineButton_Click(object sender, EventArgs e)
        {
            SetComboBoxSelectedItem(inputLanguageComboBox, translateInputTextBox);         
        }

        private void CreatePopupForm()
        {
            using (var form = new PopupForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    YandexTranslator.ApiKey = form.Key;
                }
            }
        }

        private void PopupFormInvoked(object sender, EventArgs e)
        {
            CreatePopupForm();
        }

        public YandexTranslator YandexTranslator { get; private set; }
    }
}