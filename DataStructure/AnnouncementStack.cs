using ComputeNoticeBoardDataStructure.Models;

namespace ComputeNoticeBoardDataStructure.DataStructure
{
    public class AnnouncementStack
    { //create a stack that will store the announment oject in memory
        private Stack<Announcement> _stack = new Stack<Announcement>();

        //create a variable that wll give a unique number
        private int _nextId = 1;

        //add new announcment to top of the stack
        public void Add(Announcement announcement)
        {
            announcement.Id = _nextId++;
            announcement.PostedOn = DateTime.UtcNow;
            _stack.Push(announcement);
            
        }

        //get all announcements on the stack 

        public List<Announcement> GetAnnouncements()
        {
            return new List<Announcement>(_stack);
        }

        //view announcements without removing it from the stack
        public Announcement? Peek()
        {
            //retur the top announcement 
            return _stack.Count > 0 ? _stack.Peek() : null;

            //if (_stack.Count == 0)
            //{
            //    return null;
            //}
            //return _stack.Peek();
        }

        //remove the top announcement from the stack
        public Announcement? RemoveLatest()
        {
            return _stack.Count > 0 ? _stack.Pop() : null;
        }
    }
}
