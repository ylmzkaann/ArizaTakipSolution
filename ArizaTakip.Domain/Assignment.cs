namespace ArizaTakip.Domain
{
    public class Assignment
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int AssignedToId { get; set; }
        public DateTime AssignedDate { get; set; }
        public Request? Request { get; set; }
        public User? AssignedTo { get; set; }
    }
}