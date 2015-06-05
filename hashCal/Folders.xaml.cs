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
        public void ProcessFile(string path)
        {
            
            hashfun hf = new hashfun();
            string hash=hf.MD5File(path);
            //folderresultsbox.Text = folderresultsbox.Text + path + " " + hash + "\n";
            //return hash;
            
        }

        private void calcubuttonclick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("it will take some time please wait", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            string[] fileEntries = Directory.GetFiles(folderpath.Text);
           
            //folderresultsbox.Text = "";
            foreach (string fileName in fileEntries)
            {
                //string result;
                ProcessFile(fileName);
                
            }
            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(folderpath.Text);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
       
    }
}
