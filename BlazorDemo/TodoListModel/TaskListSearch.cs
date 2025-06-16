using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListModel.Enums;

namespace TodoListModel
{
    public class TaskListSearch
    {
        public string? Name { get; set; }
        public Guid? AssigneId { get; set; }
        public Priority? priority { get; set; }
    }
}
