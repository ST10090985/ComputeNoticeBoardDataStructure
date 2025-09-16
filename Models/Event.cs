namespace ComputeNoticeBoardDataStructure.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public int Priority { get; set; }
        public DateTime Date { get; set; }    
    }
}
