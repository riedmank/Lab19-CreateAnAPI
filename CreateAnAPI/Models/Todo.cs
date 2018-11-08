using CreateAnAPI.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CreateAnAPI.Data
{
    public class Todo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public int TodoListID { get; set; }
    }
}
