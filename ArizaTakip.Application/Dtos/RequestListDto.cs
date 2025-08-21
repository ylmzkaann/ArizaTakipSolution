namespace ArizaTakip.Application.Dtos
{
    public class RequestListDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;     // enum ToString ile gelir
        public string Status { get; set; } = string.Empty;   // enum ToString ile gelir
        public DateTime CreatedDate { get; set; }
        public string CreatedByName { get; set; } = string.Empty;
    }
}