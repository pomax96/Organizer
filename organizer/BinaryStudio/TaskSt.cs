using System.Collections;

namespace BinaryStudio_Server
{
    public struct TaskSt 
    {
       
        public int TaskID { get; set; }

        // public ICollection<Subtask> SubtaskID { get; set; }
        public string Text { get; set; }
        public bool Compleatet { get; set; }
        public string Date { get; set; }
        public string Category { get; set; } 
    }
}