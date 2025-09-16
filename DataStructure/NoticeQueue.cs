using ComputeNoticeBoardDataStructure.Models;

namespace ComputeNoticeBoardDataStructure.DataStructure
{
    public class NoticeQueue
    {
        //create a queue that will store the notice object in memory

        private Queue<Notice> _queue = new Queue<Notice>();

        //create a variable that wll give a unique number
        private int _nextId = 1;

        //add new announcment to top of the stack
        public void Add(Notice notice)
        {
            notice.Id = _nextId++;
            notice.Date = DateTime.UtcNow;

            _queue.Enqueue(notice);

        }

        //get all announcements on the stack 

        public List<Notice> GeNotices()
        {
            return new List<Notice>(_queue);
        }

        //view announcements without removing it from the stack
        public Notice? Peek()
        {
            //retur the top announcement 
            return _queue.Count > 0 ? _queue.Peek() : null;

            //if (_stack.Count == 0)
            //{
            //    return null;
            //}
            //return _stack.Peek();
        }

        //remove the top announcement from the stack
        public Notice? RemoveLatest()
        {
            return _queue.Count > 0 ? _queue.Dequeue() : null;
        }
    }
}

