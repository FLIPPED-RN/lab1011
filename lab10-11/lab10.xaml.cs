using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

//НАЗАРОВ РУСЛАН 23-ИСП-2/1
//СРЕДНИЙ УРОВЕНЬ 10 ЗАДАНИЕ

namespace lab10_11
{
    public partial class lab10 : Page
    {
        private const string File1Path = "f1.txt";
        private const string File2Path = "f2.txt";
        private const string TempFilePath = "h.txt";

        public lab10()
        {
            InitializeComponent();
        }

        private async void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string content = await File.ReadAllTextAsync(File1Path);
                FileContentTextBox.Text = content;
                StatusTextBlock.Text = "File f1.txt loaded successfully.";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Error loading file f1.txt: " + ex.Message;
            }
        }

        private async void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await File.WriteAllTextAsync(File1Path, FileContentTextBox.Text);
                StatusTextBlock.Text = "Changes saved to f1.txt successfully.";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Error saving changes: " + ex.Message;
            }
        }

        private async void CopyFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string content = await File.ReadAllTextAsync(File1Path);
                await File.WriteAllTextAsync(TempFilePath, content);
                string tempContent = await File.ReadAllTextAsync(TempFilePath);
                await File.WriteAllTextAsync(File2Path, tempContent);
                StatusTextBlock.Text = "Content copied from f1.txt to f2.txt successfully.";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Error copying content: " + ex.Message;
            }
        }
    }
}
