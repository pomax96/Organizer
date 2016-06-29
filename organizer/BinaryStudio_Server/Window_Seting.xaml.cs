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

namespace BinaryStudio_Server
{
    /// <summary>
    /// Interaction logic for Window_Seting.xaml
    /// </summary>
    public partial class Window_Seting : Window
    {
        public Window_Seting()
        {
            InitializeComponent();
        }

        private void add_connection_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FileInfo file = new FileInfo("setting_server.txt");
                if (file.Exists == true)
                {
                    file.Delete();
                }
                if (file.Exists == false)
                {
                    file.Create();
                }
                Server_Setting.DataBase = @"Data Source=" + data_sourse_textbox.Text + ";Initial Catalog=" + initial_catalog_textbox.Text + ";" +
                                                   "Integrated Security=" + integrated_security_textbox.Text + ";Pooling=" + pooling_textbox.Text;
                StreamWriter write_text;
                write_text = file.AppendText();
                write_text.WriteLine(Server_Setting.DataBase);
                write_text.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void reset_setting_button_Click(object sender, RoutedEventArgs e)
        {
              FileInfo file = new FileInfo("setting_server.txt");
            if (file.Exists == true) 
            {
                file.Delete(); 
            }
            if (file.Exists == false) 
            {
                file.Create(); 
            }
            Server_Setting.DataBase = @"Data Source=.\SQLEXPRESS;Initial Catalog=database_name;" +
                                               "Integrated Security=SSPI;Pooling=False";
            StreamWriter write_text;  
            write_text = file.AppendText();
            write_text.WriteLine(Server_Setting.DataBase); 
            write_text.Close(); 
        }

        private void esc_setting_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        }
    }
