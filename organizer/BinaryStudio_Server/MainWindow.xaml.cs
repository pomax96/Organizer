using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
using System.ServiceModel;


namespace BinaryStudio_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        Uri address = new Uri("http://127.0.0.1");


        BasicHttpBinding binding = new BasicHttpBinding();


        ServiceHost service;

        
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void button_start_Click(object sender, RoutedEventArgs e)
        {
           
            
            try
            {
                if (service == null)
                {
                   

                    service = new ServiceHost(typeof(Service));

                    service.AddServiceEndpoint(typeof(IContract), binding, address);


                    service.Open();

                    textBox.Text += "Сервер запущений.         " + DateTime.Now + Environment.NewLine ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button_stop_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                if (service != null)
                {
                 
                    service.Close();
                    service = null;

                    textBox.Text += "Сервер зупинений.          " + DateTime.Now + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window_Seting setting = new Window_Seting();
            setting.Show();

        }

      
    }
        }
    

