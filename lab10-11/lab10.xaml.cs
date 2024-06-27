using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string content = File.ReadAllText(File1Path);
                FileContentTextBox.Text = content;
                StatusTextBlock.Text = "File f1.txt loaded successfully.";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Error loading file f1.txt: " + ex.Message;
            }
        }

        private void CopyFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Чтение содержимого файла f1
                string content = File.ReadAllText(File1Path);

                // Запись содержимого во временный файл h
                File.WriteAllText(TempFilePath, content);

                // Чтение содержимого временного файла h
                string tempContent = File.ReadAllText(TempFilePath);

                // Запись содержимого во второй файл f2
                File.WriteAllText(File2Path, tempContent);

                StatusTextBlock.Text = "Content copied from f1.txt to f2.txt successfully.";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Error copying content: " + ex.Message;
            }
        }
    }
}