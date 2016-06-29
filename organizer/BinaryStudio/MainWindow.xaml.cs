using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.ServiceModel;
using BinaryStudio_Server;

namespace BinaryStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        
        #region Підключення до сервера
        static Uri tcpUri = new Uri("http://127.0.0.1");

        static BasicHttpBinding binding = new BasicHttpBinding();

        static EndpointAddress address = new EndpointAddress(tcpUri);

        static ChannelFactory<IContract> factory = new ChannelFactory<IContract>(binding, address);
        IContract service = factory.CreateChannel();
        #endregion

       
        public MainWindow()
        {
            InitializeComponent();
                   
           
        }

        private void button_review_Click(object sender, RoutedEventArgs e)
        {
            Window_task w_task = new Window_task();
            w_task.Show();
        }

        private void button_add_subtask_Click(object sender, RoutedEventArgs e)
        {
            Window_Subtask Subtask = new Window_Subtask();
            Subtask.Show();
        }

       
        private void button_add_task_Click(object sender, RoutedEventArgs e)
        {
            /*try
            {*/
               // service.Update_Task();
         

               /* SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=BSOrganizerDataBase;Integrated Security=true;");

                con.Open();
                
                SqlDataAdapter DataAdapter = new SqlDataAdapter("Select * from  Task", con);
                SqlCommandBuilder ComandBuilder = new SqlCommandBuilder(DataAdapter);
                DataSet DS = new DataSet();
                DataAdapter.Fill(DS, "Task");
           

                DataGrid1.ItemsSource = DS.Tables["Task"].DefaultView;
                con.Close();*/
           /* }
            catch (DataException)
            {
                MessageBox.Show("No connection to the database");
            }
            catch(Exception)
            {
                MessageBox.Show("No connection to the server");
            }*/
            ObservableCollection<TaskSt> personColl = new ObservableCollection<TaskSt>();
            DataGrid1.ItemsSource = service.Update_Task(StaticClass.TaskID);
            
            
           StaticClass.lTask = service.Update_Task(StaticClass.TaskID);

            DataGrid1.Items.Refresh();

        }
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ObservableCollection<TaskSt> personColl = new ObservableCollection<TaskSt>();
                DataGrid2.ItemsSource = service.Show_SubTask(StaticClass.TaskID);
                StaticClass.lSubtask = service.Show_SubTask(StaticClass.TaskID);
                DataGrid2.Items.Refresh();
                
              /*  SqlConnection con = new SqlConnection(service.Server_Database());

                con.Open();

                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                DataAdapter.SelectCommand = new SqlCommand("Select * from Subtask Where (TaskID=@ID)", con);
                DataAdapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = StaticClass.TaskID;


                SqlCommandBuilder ComandBuilder = new SqlCommandBuilder(DataAdapter);
                DataSet DS = new DataSet();
                DataAdapter.Fill(DS, "Subtask");*/

               /* DataGrid2.ItemsSource = service.Update_Task(); DS.Tables["Subtask"].DefaultView;

                con.Close();*/

               // DataGrid1.ItemsSource = service.Update_Task();
              //  DataGrid1.Items.Refresh();
            }
            catch (DataException)
            {
                MessageBox.Show("No connection to the database");
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
                service.Deleted_Task();
                MessageBox.Show("Task deleted");
            }
                catch(Exception)
            {
                MessageBox.Show("No connection to the server");
            }
        }

    
              private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                  try
                  {
                     
                      int parse = DataGrid1.SelectedIndex;
                     // DataRowView rowView = DataGrid1.SelectedValue as DataRowView;
                     StaticClass.TaskID= StaticClass.lTask[parse].TaskID;
                     


                  }
                  catch (Exception)
                  {

                      MessageBox.Show("ok");
                  }
         
           /* try
            {
                DataRowView rowView = (DataRowView)DataGrid1.SelectedItem;
                DataRow row = rowView.Row;
                StaticClass.TaskID = (int)row["TaskID"];
            }
                  catch (Exception)
            {
                service.Update_Task();

                SqlConnection con = new SqlConnection(service.Server_Database());

                con.Open();

                SqlDataAdapter DataAdapter = new SqlDataAdapter("Select * from  [dbo].[Task]", con);
                SqlCommandBuilder ComandBuilder = new SqlCommandBuilder(DataAdapter);
                DataSet DS = new DataSet();
                DataAdapter.Fill(DS, "Task");

                DataGrid1.ItemsSource = DS.Tables["Task"].DefaultView;
                con.Close();        
            }*/
        }
    
        private void DataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                int parse = DataGrid2.SelectedIndex;
                StaticClass.SubtaskID = StaticClass.lSubtask[parse].SubtaskID;
          /*      DataRowView rowView = DataGrid2.SelectedValue as DataRowView;
                StaticClass.TaskID = (int)rowView[1];*/


            }
            catch (Exception)
            {

                MessageBox.Show("ok");
            }
         /*   try
            { 
                DataRowView rowView = (DataRowView)DataGrid2.SelectedItem;
                DataRow row = rowView.Row;
                StaticClass.SubtaskID = (int)row["SubtaskID"];
            }
            catch (Exception)
            {
                SqlConnection con = new SqlConnection(service.Server_Database());

                con.Open();

                SqlDataAdapter DataAdapter = new SqlDataAdapter();
                DataAdapter.SelectCommand = new SqlCommand("Select * from Subtask Where (TaskID=@ID)", con);
                DataAdapter.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = StaticClass.TaskID;


                SqlCommandBuilder ComandBuilder = new SqlCommandBuilder(DataAdapter);
                DataSet DS = new DataSet();
                DataAdapter.Fill(DS, "Subtask");

                DataGrid2.ItemsSource = DS.Tables["Subtask"].DefaultView;

                con.Close();
            }      */
        }

  

        private void DataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowYesNo YesNo = new WindowYesNo();
            YesNo.Show();  
        }

        private void DataGrid2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowYesNo_Subtask YesNo = new WindowYesNo_Subtask();
           YesNo.Show();
        }
    }
  
}
   


