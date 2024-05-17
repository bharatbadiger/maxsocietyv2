using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Maxsociety.Enums;

namespace Maxsociety.Models
{
    public class VisitorLogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VisitorLogId { get; set; }

        [ForeignKey("Visitor")]
        public long? VisitorId { get; set; }

        public Visitors? Visitor { get; set; }

        [Required]
        public DateTime VisitDateTime { get; set; }

        public VisitStatus VisitStatus { get; set; }
    }
}