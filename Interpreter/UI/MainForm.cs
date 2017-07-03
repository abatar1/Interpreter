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

        private void InitializeLanguageListControl(ListControl comboBox, IDictionary<string, string> languages, string displayMember, string valueMember)
        {
            comboBox.DataSource = new BindingSource(languages, null);
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
            comboBox.SelectedIndex = -1;
        }

        private void SetComboBoxSelectedItem(ListControl comboBox, string name)
        {
            comboBox.SelectedIndex = inputLanguageComboBox.FindString(name);
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            if (outputLanguageComboBox.SelectedItem == null)
            {
                messageLabel.Text = "Пожалуйста, выберите язык перевода.";
            }
            else if (translateInputTextBox.Text == "")
            {
                messageLabel.Text = "Пожалуйста, ввведите переводимый текст";
            }
            else
            {
                messageLabel.Text = "";

                var fromLang = "";
                if (inputLanguageComboBox.SelectedItem == null)
                {
                    fromLang = YandexTranslator.DetermineLanguage(translateInputTextBox.Text).Code;
                    SetComboBoxSelectedItem(inputLanguageComboBox, fromLang);
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
            }            
        }

        private void determineButton_Click(object sender, EventArgs e)
        {
            if (translateInputTextBox.Text == "")
            {
                messageLabel.Text = "Пожалуйста, ввведите переводимый текст";
            }
            else
            {
                var langName = YandexTranslator.DetermineLanguage(translateInputTextBox.Text).Name;
                SetComboBoxSelectedItem(inputLanguageComboBox, langName);
            }         
        }

        private void PopupFormInvoked(object sender, EventArgs e)
        {
            using (var form = new PopupForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    YandexTranslator.ApiKey = form.Key;
                }
            }
        }

        public YandexTranslator YandexTranslator { get; private set; }
    }
}
