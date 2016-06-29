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
    /// Interaction logic for WindowYesNo_Subtask.xaml
    /// </summary>
    public partial class WindowYesNo_Subtask : Window
    {
        #region Підключення до сервера
        static Uri tcpUri = new Uri("http://127.0.0.1");

        static BasicHttpBinding binding = new BasicHttpBinding();

        static EndpointAddress address = new EndpointAddress(tcpUri);

        static ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, address);
        IContract service = factory.CreateChannel();
        #endregion

        public WindowYesNo_Subtask()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            service.Compleated_Subtask(StaticClass.SubtaskID);
            MessageBox.Show("Subtask compleated");
            }
            catch (Exception)
            {
                MessageBox.Show("No connection to the server");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                service.NonCompleated_SubTask(StaticClass.SubtaskID);
                MessageBox.Show("Subtask non compleated");
            }
            catch (Exception)
            {
                MessageBox.Show("No connection to the server");
            }
        }
    }
}
