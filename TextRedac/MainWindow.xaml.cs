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
        private string filepath;
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
                string fileSod = File.ReadAllText(dialog.FileName);
                textObl.Text = fileSod;
                MessageBox.Show(dialog.FileName, "Filename", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

