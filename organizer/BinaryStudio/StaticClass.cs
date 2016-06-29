using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryStudio_Server;

namespace BinaryStudio
{
    static class StaticClass
    {
        public static IList<TaskSt> lTask = new List<TaskSt>();
        public static IList<SubTaskSt> lSubtask = new List<SubTaskSt>();
        public static int TaskID = 0;
        public static int SubtaskID = 0;
        public static string Server_IP;
        public static void Update_View()
        {

        }
    }
}
