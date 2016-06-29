using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Documents;
using BinaryStudio_Server.Migrations;


namespace BinaryStudio_Server
{
    public class Service : IContract
    {
        public string Server_Database()
        {
            return Server_Setting.DataBase;
        }

        public List<SubTaskSt> Show_SubTask(int ID)
        {
                       // context.Configuration.LazyLoadingEnabled = false;

            var _subtask = new List<SubTaskSt>();
            using (var context = new OrganaizerContext())
            {
             

                var query = from subtsk in context.Subtasks
                            where subtsk.TaskID == ID
                    select subtsk;

               
                int count = 0;
                foreach (var subtask in query)
                {
                  
                   // subtask.Task
                    count++;
                    for (int i = 0; i < 1; i += 1)
                    {
                        _subtask.Add(
                            new SubTaskSt()
                            {
                                Compleatet = subtask.Compleatet,
                                Text = subtask.Text,
                                TaskID = ID,
                                SubtaskID = subtask.SubtaskID
                               
                                
                                
                            })
                            ;
                    }
                }

            }
            return _subtask;
        }

        public List<TaskSt> Update_Task(int ID)
        {
            
            var _task = new List<TaskSt>();
            using (var context = new OrganaizerContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Tasks.Load();
                context.Subtasks.Load();


                var query = from task in context.Tasks
                            select task;

                var query1 = from sub in context.Subtasks
                             where sub.TaskID == ID
                    select sub;
        
                int count = 0;
                foreach (var task in query)
                {
                    
                    count++;
                    for (int i = 0; i < 1; i += 1) 
                    {
                        _task.Add(
                      new TaskSt()
                      {
                          Category = task.Category,
                          Compleatet = task.Compleatet,
                          Date = task.Date,
                          Text = task.Text,
                          TaskID = task.TaskID
                      })
                    ;
                    }
                  }
                context.SaveChanges();
            }
            return _task;
             
            /*  using (SqlConnection sqlConn = new SqlConnection(Server_Setting.DataBase))
            {
                const string sql = ("UPDATE Task SET Compleatet = 'True' FROM Task WHERE 'True' = ALL (SELECT Compleatet FROM Subtask WHERE Subtask.TaskID=Task.TaskID) AND EXISTS (SELECT * FROM Subtask WHERE Subtask.TaskID=Task.TaskID)");
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);


                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
            }*/
        }
        public void NonCompleated_Task(int ID)
        {

            using (var context = new OrganaizerContext())
            {
                var query = from task in context.Tasks
                    where task.TaskID == ID
                    select task ;
                foreach (var task in query)
                {
                    task.Compleatet = false;
                    
                }
                context.SaveChanges();

            }
          /*  using (SqlConnection sqlConn = new SqlConnection(Server_Setting.DataBase))
            {
                const string sql = ("UPDATE Task SET Compleated = 'False' FROM Task  WHERE (Task.TaskID =@ID)");
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                sqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;


                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
*/


        }

        public void NonCompleated_SubTask(int ID)
        {

            using (var context = new OrganaizerContext())
            {
                var query = from subtask in context.Subtasks
                    where subtask.SubtaskID == ID
                    select subtask;
                foreach (var subtask in query)
                {
                    subtask.Compleatet = false;

                }
                context.SaveChanges();
            }

            /* using (SqlConnection sqlConn = new SqlConnection(Server_Setting.DataBase))
            {
                const string sql = ("UPDATE Subtask SET Compleated = 'False' FROM Subtask  WHERE (Subtask.SubtaskID =@ID)");
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                sqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;


                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }*/
        }


        public void Compleated_Subtask(int ID)
        {

            using (var context = new OrganaizerContext())
            {
                var query = from subtask in context.Subtasks
                    where subtask.SubtaskID == ID
                    select subtask;
                foreach (var subtask in query)
                {
                    subtask.Compleatet = true;

                }
                context.SaveChanges();
            }
            /*  using (SqlConnection sqlConn = new SqlConnection(Server_Setting.DataBase))
            {
                const string sql = ("UPDATE Subtask SET Compleated = 'True' FROM Subtask  WHERE (Subtask.SubtaskID =@ID)");
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                sqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;


                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }*/
           
        }

        public void Compleated_Task(int ID)
        {

            using (var context = new OrganaizerContext())
            {
                var query = from task in context.Tasks
                    where task.TaskID == ID
                    select task ;
                foreach (var task in query)
                {
                    task.Compleatet = true;
                    
                }
                context.SaveChanges();

            }
            /*   using (SqlConnection sqlConn = new SqlConnection(Server_Setting.DataBase))
            {
                const string sql = ("UPDATE Task SET Compleated = 'True' FROM Task  WHERE (Task.TaskID =@ID)");
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                sqlCmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;


                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }*/
           

             
        }
        
        public void Deleted_Task()
        {
            using (var context = new OrganaizerContext())
            {
                var query = from task in context.Tasks
                    where task.Compleatet == true
                    select task;

                foreach (var task in query)
                {
                    context.Tasks.Remove(task);
                }
                context.SaveChanges();
            }
        /*    SqlConnection sqlConn = new SqlConnection(Server_Setting.DataBase);
            sqlConn.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;

            string sql = string.Format("DELETE Task FROM Task WHERE ([Task].[Compleated] = 'True')");

            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                cmd.ExecuteNonQuery();
            }


            sqlConn.Close();*/
                }
        public void add_Subtask(int ID, string Text, bool Compleated)
        {
            using (var context = new OrganaizerContext())
            {
                var subtask = new Subtask
                {
                   TaskID = ID,
                   Text = Text,
                   Compleatet = Compleated
                  
                   
                };

                context.Subtasks.Add(subtask);
                context.SaveChanges();

            }
            /*SqlConnection sqlConn = new SqlConnection(Server_Setting.DataBase);
            sqlConn.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;

            string sql = string.Format("Insert Into dbo.Subtask " +
                  "(TaskID,Text, Compleated) Values('{0}','{1}','{2}')",
                  ID, Text, Compleated);

            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                cmd.ExecuteNonQuery();
            }


            sqlConn.Close();*/
        }



    
    
        public void add_Task(string input1, string input2, string input3, bool input4)
        {
            using (var context = new OrganaizerContext())
            {
                var task = new Task 
                {
                    Category = input1,
                    Compleatet = input4,
                    Date = input3, 
                    Text = input2
                };

                context.Tasks.Add(task);
                context.SaveChanges();

            }
           /* SqlConnection sqlConn = new SqlConnection(Server_Setting.DataBase);
            sqlConn.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlConn;

            string sql = string.Format("Insert Into dbo.Task " +
                  "(Category, Text, Date, Compleated) Values('{0}','{1}','{2}','{3}')",
                  input1, input2, input3.ToString() , input4);
            
            using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
            {
                cmd.ExecuteNonQuery();
            }


            sqlConn.Close();*/
        }


      

    }

  
    }




