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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace hashCal
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

    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textinput.Text = "";
            ClearTextBox();

        }
        private void ClearTextBox()
        {
            
            sha1outbox.Text = "";
            md5outbox.Text = "";
            sha256outbox.Text = "";
            sha512outbox.Text = "";
            
        }
        private void StartCal_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox();//to clear the previous calculated hash valus from boxes if any
            if (textinput.Text == "")
            {
                MessageBox.Show("Enter the Text to Calculate", "hashCal", MessageBoxButton.OK, MessageBoxImage.Stop);

            }
            else
            {
                hashfunctions hf = new hashfunctions();//creating a object for hashfunctions to use them 

                if (md5cb.IsChecked == true)
                {
                    md5outbox.Text = hf.CalMD5Hash(textinput.Text);

                }
                if (sha1cb.IsChecked == true)
                {
                    sha1outbox.Text = hf.CalSHA1Hash(textinput.Text);
                }
                if (sha256cb.IsChecked == true)
                {
                    sha256outbox.Text = hf.CalSHA256Hash(textinput.Text);
                }
                if (sha512cb.IsChecked == true)
                {
                    sha512outbox.Text = hf.CalSHA512Hash(textinput.Text);
                }
                if (md5cb.IsChecked == false && sha1cb.IsChecked == false && sha256cb.IsChecked == false && sha512cb.IsChecked == false)
                {
                    MessageBox.Show("Select the Hashing Algo", "hashCal", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FHWindows fh = new FHWindows();
            fh.Show();
        }

        private void TextMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();

        }

        private void FolderMenuBar(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Folders fw = new Folders();
            fw.Show();

        }
        
    }
    public class hashfunctions
    {
        public string CalMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public string CalSHA1Hash(string input)
        {
            // step 1, calculate SHA1 hash from input
            SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha1.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public string CalSHA256Hash(string input)
        {
            // step 1, calculate SHA256 hash from input
            SHA256 sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = sha256.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public string CalSHA512Hash(string input)
        {
            // step 1, calculate SHA512 hash from input
            SHA512 SHA = System.Security.Cryptography.SHA512.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = SHA.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
