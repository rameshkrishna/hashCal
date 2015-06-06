using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography;



namespace hashCal
{
    /// <summary>
    /// Interaction logic for FHWindows.xaml
    /// </summary>
    public partial class FHWindows : Window
    {
        public FHWindows()
        {
            InitializeComponent();
        }

        private void TextMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "hashCal";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.RestoreDirectory = true;
            Nullable<bool> result = fdlg.ShowDialog();
            if (result == true)
            {
                filepathbox.Text = fdlg.FileName;
            }
        }

        private void ClearTextBox()
        {
            sha1outbox.Text = "";
            md5outbox.Text = "";
            sha256outbox.Text = "";
            sha512outbox.Text = "";
        }

        

        public void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            if (!File.Exists(filepathbox.Text))
            {
                MessageBox.Show("Select the File", "hashCal", MessageBoxButton.OK, MessageBoxImage.Stop);

            }
             else if (md5cb1.IsChecked == true || sha1cb1.IsChecked == true || sha256cb1.IsChecked == true || sha512cb1.IsChecked == true)
             {
                 hashfun hf = new hashfun();
                 if (md5cb1.IsChecked == true)
                 {
                     md5outbox.Text = hf.MD5File(filepathbox.Text);
                 }
                 if (sha1cb1.IsChecked == true)
                 {
                     sha1outbox.Text = hf.SHA1File(filepathbox.Text);
                 }
                 if (sha256cb1.IsChecked == true)
                 {
                     sha256outbox.Text = hf.SHA256File(filepathbox.Text);
                 }
                 if (sha512cb1.IsChecked == true)
                 {
                     sha512outbox.Text = hf.SHA512File(filepathbox.Text);
                 }
             }
             else
             {
                 MessageBox.Show("Select the Hash Algo", "hashCal", MessageBoxButton.OK, MessageBoxImage.Stop);
             }

        
        }

        private void File1Selector(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "hashCal";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.RestoreDirectory = true;
            Nullable<bool> result = fdlg.ShowDialog();
            if (result == true)
            {
                file1pathbox.Text = fdlg.FileName;
            }
        }

        private void file2selector(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "hashCal";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.RestoreDirectory = true;
            Nullable<bool> result = fdlg.ShowDialog();
            if (result == true)
            {
                file2pathbox.Text = fdlg.FileName;
            }
        }

        private void compare_file(object sender, RoutedEventArgs e)
        {
            hashfun hf = new hashfun();
            FileCompResbox.Background = System.Windows.Media.Brushes.WhiteSmoke;
            FileCompResbox.Content = "";
            if (File.Exists(file1pathbox.Text) && File.Exists(file2pathbox.Text))
            {
                if (hf.MD5File(file1pathbox.Text) == hf.MD5File(file2pathbox.Text))
                {

                    FileCompResbox.Background = System.Windows.Media.Brushes.LawnGreen;
                    FileCompResbox.Content = "Both are Same";

                }
                else
                {
                    FileCompResbox.Background = System.Windows.Media.Brushes.Red;
                    FileCompResbox.Content = "Both are Different";
                }
            }
            else
            {
                MessageBox.Show("Enter the File Path Properly", "hashCal", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void foldermenuclick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Folders fw = new Folders();
            fw.Show();

        }
        
    }
    public class hashfun{

        public string MD5File(string fileName)
        {
            
            var md5 = MD5.Create();
            
                var stream = File.OpenRead(fileName);
                return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
        }
        public string SHA1File(string fileName)
        {
            var sha1 = SHA1.Create();
            var stream = File.OpenRead(fileName);
            return BitConverter.ToString(sha1.ComputeHash(stream)).Replace("-", string.Empty);

        }
        public string SHA256File(string fileName)
        {
            var sha256 = SHA256.Create();
            var stream = File.OpenRead(fileName);
            return BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", string.Empty);

        }
        public string SHA512File(string fileName)
        {
            var sha512 = SHA512.Create();
            var stream = File.OpenRead(fileName);
            return BitConverter.ToString(sha512.ComputeHash(stream)).Replace("-", string.Empty);
        }
    }
        
}
