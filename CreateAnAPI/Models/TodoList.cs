using CreateAnAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateAnAPI.Models
{
    public class TodoList
    {
        public int ID { get; set; }
        public string ListTitle { get; set; }
        public Todo Todoes { get; set; }
    }
}
