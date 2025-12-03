using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextRedac
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textObl.CaretIndex = 0;
            textObl.Focus();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые документы (*.txt)|*.txt|Файлы Markdown (*.md)|*.md|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            //dialog.ShowDialog();
          
            if (dialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                StreamReader read = new StreamReader(dialog.FileName);
                string fileSod = read.ReadLine();
                textObl.Text = fileSod;
                MessageBox.Show(dialog.FileName, "Filename", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string currentFilePath;
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Текстовые документы (*.txt)|*.txt|Файлы Markdown (*.md)|*.md|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.DefaultExt = ".txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                StreamWriter write = new StreamWriter(saveFileDialog.FileName);
              
                    write.Write(textObl.Text);
                    write.Close();
                    //File.WriteAllText(saveFileDialog.FileName, textObl.Text);
                    MessageBox.Show(saveFileDialog.FileName, "Filename", MessageBoxButton.OK, MessageBoxImage.Information);
                    currentFilePath = filePath;
            }
        }
      
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (currentFilePath == null)
                MenuItem_Click_1(sender, e);
            else
            {
                File.WriteAllText(currentFilePath, textObl.Text);
                MessageBox.Show("Файл перезаписан!");
            }
        }
    }
}


