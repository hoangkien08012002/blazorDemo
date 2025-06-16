using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListModel.Enums;

namespace TodoListModel
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; } = new Guid();

        [MaxLength(20, ErrorMessage ="you can't fill task name over than 20 characters")]
        [Required(ErrorMessage ="Please enter task name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please Select priority")]
        public Priority? Priority { get; set; }
    }
}
