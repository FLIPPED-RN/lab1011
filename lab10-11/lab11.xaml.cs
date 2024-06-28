using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

//НАЗАРОВ РУСЛАН
//СРЕДНИЙ УРОВЕНЬ 18 ЗАДАНИЕ

namespace lab10_11
{
    public partial class lab11 : Page
    {
        private const string FilePath = "numbers.bin";

        public lab11()
        {
            InitializeComponent();
        }

        private void ProcessNumbers(object sender, RoutedEventArgs e)
        {
            string[] inputNumbers = InputTextBox.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = inputNumbers.Select(int.Parse).ToArray();

            WriteNumbersToFile(numbers);
            string beforeText = "Числа до изменения: " + String.Join(", ", numbers);
            BeforeChangeText.Text = beforeText;

            int[] modifiedNumbers = ReadAndModifyNumbers();
            string afterText = "Числа после изменения: " + String.Join(", ", modifiedNumbers);
            AfterChangeText.Text = afterText;
        }

        private void WriteNumbersToFile(int[] numbers)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.Create)))
            {
                foreach (int number in numbers)
                {
                    writer.Write(number);
                }
            }
        }

        private int[] ReadAndModifyNumbers()
        {
            int[] numbers;
            using (BinaryReader reader = new BinaryReader(File.Open(FilePath, FileMode.Open)))
            {
                var numList = new System.Collections.Generic.List<int>();
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    numList.Add(reader.ReadInt32());
                }
                numbers = numList.ToArray();
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                    numbers[i] += 3;
                else
                    numbers[i] -= 3;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FilePath, FileMode.Create)))
            {
                foreach (int number in numbers)
                {
                    writer.Write(number);
                }
            }

            return numbers;
        }
    }
}
