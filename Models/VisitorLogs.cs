using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maxsociety.Enums;

namespace Maxsociety.Models
{
    public class VisitorLogs : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Visitor")]
        public long? VisitorId { get; set; }

        public Visitors? Visitor { get; set; }

        public string? Block { get; set; }

        public string? FlatNo { get; set; }

        public string? Type { get; set; }

        public string? VisitPurpose { get; set; }

        [MaxLength(60)]
        public string? ResidentName { get; set; }

        public VisitStatus VisitStatus { get; set; }
    }
}