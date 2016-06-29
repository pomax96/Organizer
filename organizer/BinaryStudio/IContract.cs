using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Documents;
using BinaryStudio_Server;


namespace BinaryStudio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IContract
    {
      /*  [OperationContract]
        string Server_IP();*/

        [OperationContract]
        string Server_Database();

        [OperationContract]
        List<SubTaskSt> Show_SubTask(int ID);

        [OperationContract]
        List<TaskSt> Update_Task(int ID);

        [OperationContract]
        void NonCompleated_Task(int ID);

        [OperationContract]
        void NonCompleated_SubTask(int ID);

        [OperationContract]
        void Compleated_Task(int ID);

        [OperationContract]
        void Compleated_Subtask(int ID);
        [OperationContract]
        void Deleted_Task();
        [OperationContract]
        void add_Task(string input1, string input2, string input3, bool input4);

     
        [OperationContract]
        void add_Subtask(int ID, string Text, bool Compleated);

       // [OperationContract]
       // object Task_View();
       }

}
