using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Todo.Entities
{
    public class Role : IdentityRole<Guid>
    {
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }

    }
}
