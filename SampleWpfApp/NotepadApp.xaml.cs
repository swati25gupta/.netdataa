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
using System.Windows.Shapes;

namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for NotepadApp.xaml
    /// </summary>
    public partial class NotepadApp : Window
    {
        static string filename = string.Empty;
        public NotepadApp()
        {
            InitializeComponent();
        }

        private void onSave(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog(this);
            filename = dlg.FileName;
            if (string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("no file name is selected");
                return;
            }
            StreamWriter writer = new StreamWriter(filename);
            writer.Write(txtContent.Text);
            writer.Flush();
            writer.Close();
        }

        private void onOpen(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.ShowDialog(this);//modal Dialog
            filename = dlg.FileName;
            if(string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("No file is selcted to view");
                return;
            }
            StreamReader reader = new StreamReader(filename);
            txtContent.Text = reader.ReadToEnd();
            reader.Close();
        }
    }
}
