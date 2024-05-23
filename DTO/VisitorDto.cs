using Maxsociety.Enums;

namespace Maxsociety.DTO
{
    public class VisitorDto
    {
        public long Id { get; set; }
        public string? VisitorName { get; set; }
        public string? MobileNo { get; set; }
        public Gender Gender { get; set; }
        public string? Email { get; set; }
        public string? ImagePath { get; set; }
        public VisitorLogDto? LastVisitorLog { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class VisitorLogDto
    {
        public long Id { get; set; }
        public long? VisitorId { get; set; }
        public string? Block { get; set; }
        public string? FlatNo { get; set; }
        public string? Type { get; set; }
        public string? VisitPurpose { get; set; }
        public string? ResidentName { get; set; }
        public VisitStatus VisitStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}


