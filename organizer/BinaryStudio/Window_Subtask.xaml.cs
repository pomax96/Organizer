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
using System.ServiceModel;

namespace BinaryStudio
{
    /// <summary>
    /// Interaction logic for Window_Subtask.xaml
    /// </summary>
    public partial class Window_Subtask : Window
    {
        #region Підключення до сервера
        static Uri tcpUri = new Uri("http://127.0.0.1");

        static BasicHttpBinding binding = new BasicHttpBinding();

        static EndpointAddress address = new EndpointAddress(tcpUri);

        static ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, address);
        IContract service = factory.CreateChannel();
        #endregion
        public Window_Subtask()
        {
            InitializeComponent();
           
        }

        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                service.add_Subtask(StaticClass.TaskID, TextBox_Text.Text, false);
                MessageBox.Show("Subtask add");
            }
            catch(Exception)
            {
                MessageBox.Show("No connection to the server");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
