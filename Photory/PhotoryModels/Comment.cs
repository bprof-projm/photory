using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhotoryModels
{
    public class Comment
    {
        [Key]
        public string CommentID { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string CommentContent { get; set; }

        [Required]
        public string PhotoID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Photo Photo { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}