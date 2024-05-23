using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maxsociety.Enums;

namespace Maxsociety.Models
{
    public class Visitors : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string? VisitorName { get; set; }

        [Required]
        [MaxLength(14)]
        public string? MobileNo { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string? Email { get; set; }

        public string? ImagePath { get; set; }

    }
}
