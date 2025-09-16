using ComputeNoticeBoardDataStructure.Models;

namespace ComputeNoticeBoardDataStructure.DataStructure
{
    public class EventPriorityQueue
    {
        //this class will sort all events in a priority queue
        // in a sorted manner
        //lower priority number means higher priority for eample  = Highest


        //create a list that will hold events
        private List<Event> _events = new List<Event>();

        //crete a variable that wll give a unique ID
        private int _nextId = 1;

        //create a method to add an Event, and store them by priority 
        public void Add(Event e)
        {
            e.Id = _nextId++;
            e.Date = DateTime.UtcNow;
            //add the event to the list
            _events.Add(e);
            //sort the list by priority (lower number means higher priority)
            _events = _events.OrderBy(r => r.Priority).ThenBy(r => r.Date).ToList();
        }

        //create a method to get all events
        public List<Event> GetEvents()
        {
            return _events.ToList();
        }

        //create a method to peek at the highest priority event without removing it
        public Event? Peek()
        {
            return _events.Count > 0 ? _events[0] : null;
        }

        //create a method to remove the highest priority event
        public Event? RemoveHighestPriority()
        {
            if (_events.Count == 0)
            {
                return null;
            }
            var highestPriorityEvent = _events[0];
            _events.RemoveAt(0);
            return highestPriorityEvent;
        }
    }
}
