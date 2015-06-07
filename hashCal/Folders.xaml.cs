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

namespace hashCal
{
    /// <summary>
    /// Interaction logic for Folders.xaml
    /// </summary>
    public partial class Folders : Window
    {
        public Folders()
        {
            InitializeComponent();
        }

        public void folderselectbutton(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog fd = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            fd.UseDescriptionForTitle = true;
            
            fd.ShowDialog();
            folderpath.Text = fd.SelectedPath;
            
        }
        public  void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                 ProcessFile(fileName);
            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        public string res;
        public void ProcessFile(string path)
        {
            hashfun hf = new hashfun();
             string md5hash="";
             string sha1hash="";
             string sha256hash="";
             string sha512hash="";
            if (md5checkboxf.IsChecked == true)
            {
                md5hash = hf.MD5File(path);
            }
            if (sha1checkboxf.IsChecked==true)
            {
                sha1hash = hf.SHA1File(path);
            }
            if (sha256checkboxf.IsChecked == true)
            {
                sha256hash = hf.SHA256File(path);
            }
            if (sha512checkboxf.IsChecked == true)
            {
                sha512hash = hf.SHA512File(path);
            }
            path=System.IO.Path.GetFileName(path);
            res = res + path + "," +md5hash+","+sha1hash+","+sha256hash+","+sha512hash+","+"\n";       
        }

        public void calcubuttonclick(object sender, RoutedEventArgs e)
        {
            
            if (Directory.Exists(folderpath.Text) == true)
            {
                if (md5checkboxf.IsChecked == true || sha1checkboxf.IsChecked == true || sha256checkboxf.IsChecked == true || sha512checkboxf.IsChecked == true)
                {
                    MessageBox.Show("it will take some time please wait", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    string[] fileEntries = Directory.GetFiles(folderpath.Text);

                    //folderresultsbox.Text = "";
                    foreach (string fileName in fileEntries)
                        ProcessFile(fileName);
                    // Recurse into subdirectories of this directory. 
                    string[] subdirectoryEntries = Directory.GetDirectories(folderpath.Text);
                    foreach (string subdirectory in subdirectoryEntries)
                        ProcessDirectory(subdirectory);

                    string completeout = res;
                    FolderOutPutWindowTable fo = new FolderOutPutWindowTable(completeout);
                    completeout = "";
                    fo.Show();
                }
                else
                {
                    MessageBox.Show("Select Hash Algos", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            else
            {
                MessageBox.Show("Could not find the directory", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void filemenuclick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FHWindows fw = new FHWindows();
            fw.Show();
        }

        private void textmenuclick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();

        }
       
    }
}
