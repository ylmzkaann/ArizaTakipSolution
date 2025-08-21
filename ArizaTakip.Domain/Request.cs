namespace ArizaTakip.Domain
{
    public class Request
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public RequestType Type { get; set; } = RequestType.BT;
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;   // EF dolduracak

        // İstersen: tek atama ilişkisi
        public Assignment? Assignment { get; set; }
    }
}