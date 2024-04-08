using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FunOlympic1
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }


        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }
        // Navigation property to access the associated IdentityUser
        public virtual IdentityUser User { get; set; }

        public int VideoUploadId { get; set; }
        public virtual Video Video { get; set; }

    }
}
