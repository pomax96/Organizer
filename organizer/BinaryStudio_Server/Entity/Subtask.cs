using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStudio_Server
{
    class Subtask
    {
       
        public int SubtaskID { get; set; }
        public int TaskID { get; set; }
        public ICollection<Task> Tasks { get; set; }

       public string Text { get; set; }
        public bool Compleatet { get; set; }

          public Subtask()
        {
            this.Tasks = new List<Task>();
        }

    }
}
