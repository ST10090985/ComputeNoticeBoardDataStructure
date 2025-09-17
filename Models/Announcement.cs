namespace ComputeNoticeBoardDataStructure.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
