using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TodoListModel.Enums;

namespace TodoListModel
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }

        public Guid? AssigneId { get; set; }

        public string? AssigneName { get; set; }
        public DateTime CreateDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
