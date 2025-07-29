namespace ArizaTakip.Domain
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public RequestType Type { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CreatedById { get; set; }
        public User? CreatedBy { get; set; }
        public Assignment? Assignment { get; set; }
    }
}