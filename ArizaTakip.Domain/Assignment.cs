using ArizaTakip.Domain;

public class Assignment
{
    public int Id { get; set; }

    // Talep
    public int RequestId { get; set; }
    public Request Request { get; set; } = null!;   

    // Teknisyen
    public int TechnicianId { get; set; }
    public User Technician { get; set; } = null!;   

    public DateTime AssignedAt { get; set; } = DateTime.Now;
}