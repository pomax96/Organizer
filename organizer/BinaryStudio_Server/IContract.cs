using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace BinaryStudio_Server
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        string Server_Database();
        /*[OperationContract]
        string Server_IP();*/

        [OperationContract]
        List<TaskSt> Update_Task(int ID);
           [OperationContract]
        List<SubTaskSt> Show_SubTask(int ID);

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
       //  [OperationContract]
       // object Task_View();
    }
}
