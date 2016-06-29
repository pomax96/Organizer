using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStudio_Server
{
     class Task
    {
        
        public int TaskID { get; set; }

        public Subtask Subtask { get; set; }
        public string Text { get; set; }
        public bool Compleatet { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }


       

    }
}
