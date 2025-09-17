using Microsoft.AspNetCore.Mvc;
using ComputeNoticeBoardDataStructure.Models;
using ComputeNoticeBoardDataStructure.DataStructure;

namespace ComputeNoticeBoardDataStructure.Controllers
{
    public class BoardController : Controller
    {
        //create a reference fo all data structure
        private static AnnouncementStack _annStack = new AnnouncementStack();
        private static NoticeQueue _noticesQueue = new NoticeQueue();
        private static EventPriorityQueue _eventQueue = new EventPriorityQueue();

        //private static DataStructure.EventPriorityQueue _eventPriorityQueue = new DataStructure.EventPriorityQueue();

        // will reurn the latest announcment /event top items from our data

        public IActionResult Index()
        {
            //pass the latest announcment, notice and event to the view using ViewBag

            ViewBag.LatestAnnouncement = _annStack.Peek();
            ViewBag.NextQueue = _noticesQueue.Peek();
            ViewBag.TopEvent = _eventQueue.Peek();

            return View();
        }

        public IActionResult Announcements()
        {
            //grab all he announcements from the latest announcment stack or top 

            //var announcements = _annStack.GetAnnouncements();
            return View(_annStack.GetAnnouncements());
        }

        //give the user the abiliy to add a new announcment

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddAnnouncement(Announcement announcement)
        {
            _annStack.Add(announcement);

            return RedirectToAction("Announcement");
        }

        public IActionResult RemoveAnnouncement()
        {
            _annStack.RemoveLatest();
            return RedirectToAction("Announcement");
        }

        //queue for notices
        //show all queues

        public IActionResult Notices()
        {
            return View(_noticesQueue.GeNotices());
        }

        //show the form to the user 

        [HttpGet]

        public IActionResult AddNotice()
        {
            return View();
        }

        [HttpGet]

        public IActionResult AddNotice(Notice notice)
        {
            _noticesQueue.Add(notice);
            return RedirectToAction("Announcement");
        }

        public IActionResult RemoveNotice()
        {
            _noticesQueue.RemoveLatest();
            return View(_noticesQueue.GeNotices());
        }

        //priority queue for events

        public IActionResult Events()
        {
            var events = _eventQueue.GetEvents();
            return View(events);
        }

        //show the form to the user 

        [HttpGet]

        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddEvent(Event e)
        {
            _eventQueue.Add(e);
            return RedirectToAction("Events");
        }

        public IActionResult RemoveEvent()
        {
           _eventQueue.RemoveHighestPriority();
            return View(_eventQueue.GetEvents());
        }
    }
}
