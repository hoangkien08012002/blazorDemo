﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Entities
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(100)]
        [Required]
        public string FirstName {  get; set; }
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

    }
}
