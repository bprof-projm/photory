using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PhotoryModels
{
    public class UserOfGroup
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }

        public bool IsPending { get; set; }

        [Required]
        public string GroupName { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Group Group { get; set; }
    }
}