using Microsoft.VisualBasic;
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

namespace WPFWordPadHomework
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
        private void openFile(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                var str = openFileDialog.FileName;
                string text = File.ReadAllText(str).ToString();
                fileTextBox.Text = str;
                textBox.Text = text;

            }
        }

        string path = "";
        private void saveFile(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text.ToString());
                textBox.Text = "";
                fileTextBox.Text = "";
                path = saveFileDialog.FileName;
            }
        }

        private void selectAll(object sender, MouseButtonEventArgs e)
        {

            textBox.SelectAll();
        }


        private void copyText(object sender, MouseButtonEventArgs e)
        {
            textBox.Copy();
            
        }

        private void pastText(object sender, MouseButtonEventArgs e)
        {
            textBox.Paste();
        }

        private void cutText(object sender, MouseButtonEventArgs e)
        {
            textBox.Cut();
        }

        private void autoSaveFIle(object sender, TextChangedEventArgs e)
        {
            if (path == "")
            {
                checkBox.IsEnabled = false;
            }
            else if (path != "")
            {
                checkBox.IsEnabled = true;
                if (checkBox.IsChecked == true)
                {
                    File.WriteAllText(path, textBox.Text.ToString());
                }
                
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            checkBox.IsEnabled = false;
        }

        private void saveFileText(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                File.WriteAllText(path, textBox.Text.ToString());
            }
        }

        private void changStyle(object sender, MouseButtonEventArgs e)
        {
            if (textBox.SelectionLength == 0)
            {
                textBox.FontStyle = FontStyles.Italic;
            }
            else 
            {
                TextBox a = new TextBox();
                a.Text = textBox.SelectedText;
                a.FontStyle = FontStyles.Italic;
                
            }
        }
    }
}
