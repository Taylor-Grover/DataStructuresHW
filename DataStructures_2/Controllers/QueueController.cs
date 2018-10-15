/*********************************************************************
 Authors: Rhett Burton, Taylor Grover, Justin Schwendiman, Isaac White
 Date modified: Oct 15, 2018
*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures_2.Controllers
{
    public class QueueController : Controller
    {

        static Queue<String> progQueue = new Queue<string>();

        // GET: Queue
        public ActionResult Index()
        {
            ViewBag.myQueue = progQueue;
            return View();
        }
        //Add one item to Queue
        public ActionResult AddOneItemToQueue()
        {
            progQueue.Enqueue("New Entry " + (progQueue.Count() + 1));
            ViewBag.myQueue = progQueue;
            return View("Index");
        }
        //Add many items to Queue
        public ActionResult AddManyItemsToQueue()
        {
            progQueue.Clear();
            string addMe = "";
            while (progQueue.Count() < 2001)
            {
                addMe = "New Entry " + progQueue.Count();
                progQueue.Enqueue(addMe);
            }
            ViewBag.myQueue = progQueue;
            return View("Index");
        }
        //Display Queue
        public ActionResult DisplayQueue()
        {
            ViewBag.myQueue = progQueue;
            return View("Index");
        }
        //Delete item from Queue
        public ActionResult DeleteFromQueue()
        {
            bool isFound = false;
            //create a new queue       
            Queue<string> updatedQueue = new Queue<string>();
            string itemToDelete = Request.Form["ItemToDelete"];

            while(progQueue.Count() > 0)
            {
                if(progQueue.Peek() == itemToDelete)
                {
                    isFound = true;
                    progQueue.Dequeue();
                }
                else
                {
                    string temp = progQueue.Peek();
                    updatedQueue.Enqueue(temp);
                    progQueue.Dequeue();
                }
            }
            if (isFound)
            {
                progQueue = updatedQueue;
                ViewBag.myQueue = updatedQueue;
                return View("Index");
            }
            else
            {
                ViewBag.Output = "Sorry, the item you are looking for does not exist. Please try again";
                return View();
            }  
        }
        //Method to Clear Queue
        public ActionResult ClearQueue()
        {
            progQueue.Clear();
            ViewBag.myQueue = progQueue;
            return View("Index");
        }

        //Method to search for item in Queue
        public ActionResult SearchQueue()
        {
            bool isFound = false;
            string foundIt = "";
            int position = 0;
            //Loop through Queue to find the element
            string findMe = Request.Form["findMe"];
            foreach (string element in progQueue)
            {
                if (element == findMe)
                {
                    isFound = true;
                    foundIt = element;
                    position = progQueue.Count();

                }
            }
            if (!isFound)
            {
                ViewBag.Output = "Sorry, the item you are looking for is not in the Queue.";
            }
            else
            {
                ViewBag.Output = foundIt + " was in position " + position + " of the Queue." ;
            }
            return View();
        }
        public ActionResult AddCustomItem()
        {
            string addMe = "";
            addMe = Request.Form["addMe"];
            progQueue.Enqueue(addMe);
            ViewBag.myQueue = progQueue;
            return View("Index");
        }
    }
}