using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SerilogLearningDemo
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Comment("Foydalanuvchi ismi")]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        [Comment("Elektron pochta manzili")]
        public string Email { get; set; }
        [Required]
        [Comment("Kirish uchun parol")]
        [Column(TypeName = "varchar(43)")]
        public string Password { get; set; }
    }
}
