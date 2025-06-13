﻿using System;
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
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }
        public Priority Priority { get; set; }
    }
}
