using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoListApi.Enums;

namespace TodoListApi.Entities
{
    public class Taskss
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }
        
        public Guid AssigneId { get; set; }
        [ForeignKey(nameof(AssigneId))]
        public User Assigne {  get; set; }
        
        public DateTime CreateDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
