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
    public class StackController : Controller
    {
        

        static Stack<String> progStack = new Stack<String>();


        // GET: Stack
        public  ActionResult Index()
        {
            ViewBag.myStack = progStack;
            return View();
        }

        //Method to add 1 item to Stack
        public ActionResult AddOneItemToStack()
        {
            progStack.Push("New Entry " + (progStack.Count() + 1));
            ViewBag.myStack = progStack;
            return View("Index");
        }
        //Method to add 2000 generated vals to stack
        public ActionResult AddManyItemsToStack()
        {
            progStack.Clear();
            string addMe = "";
            while (progStack.Count() < 2001)
            {
                addMe = "New Entry " + progStack.Count();
                progStack.Push(addMe);
            }
            ViewBag.myStack = progStack;
            return View("Index");
        }
        //Method to display stack
        public ActionResult DisplayStack()
        {
            ViewBag.myStack = progStack;
            return View("Index");
        
        }
        //Method to delete an item from the stack
        public ActionResult DeleteFromStack()
        {
            bool isFound = false;
            //Create 2 stacks
            Stack<String> tempStack = new Stack<string>();
            Stack<String> updatedStack = new Stack<string>();
            //Get user input
            string itemToDelete = Request.Form["ItemToDelete"];
            //Search for item to delete while storing the remaining items in a temporary stack
            while (progStack.Count() > 0)
            {
                if (progStack.Peek() == itemToDelete)
                {
                    isFound = true;
                    progStack.Pop();
                }
                else
                {
                    string temp = progStack.Peek();
                    tempStack.Push(temp);
                    progStack.Pop();
                }
            }
            //Since the stack is in reverse order, switch back the temp stack into an updated stack
            while (tempStack.Count() > 0)
            {
                string temp = tempStack.Peek();
                updatedStack.Push(temp);
                tempStack.Pop();
            }
            if (isFound)
            {
                progStack = updatedStack;
                ViewBag.myStack = progStack;
                return View("Index");
            }
            else
            {
                ViewBag.Output = "Sorry the item you are looking for does not exist. Please try again";
                return View();
            }
        }

        //Method to Clear Stack
        public ActionResult ClearStack()
        {
            progStack.Clear();
            ViewBag.myStack = progStack;
            return View("Index");
        }

        //Method to search for item in stack
        public ActionResult SearchStack()
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            
            bool isFound = false;
            string foundIt = "";      
            int position = 0;
            timer.Start();
            //Loop through stack to find the element
            string findMe = Request.Form["findMe"];
            foreach (string element in progStack)
            {
                if (element == findMe)
                {
                    isFound = true;
                    foundIt = element;
                    position = progStack.Count();

                }
            }
            if (!isFound)
            {
                timer.Stop();
               TimeSpan timeElapsed = timer.Elapsed;
                 
               ViewBag.Output = "Sorry, the item you are looking for is not in the stack." + "This search took: " + timeElapsed.ToString(@"mm\:ss\:fffffff") + " (minutes:seconds:fraction of seconds)";
            }
            else
            {
                timer.Stop();
                TimeSpan timeElapsed = timer.Elapsed;
                ViewBag.Output = foundIt + " was in position " + position + " of the Stack." + "This search took: " + timeElapsed.ToString(@"mm\:ss\:fffffff") + " (minutes:seconds:fraction of seconds)";
            }
            return View();
        }
        public ActionResult AddCustomItem()
        {
            string addMe = "";
            addMe = Request.Form["addMe"];
            progStack.Push(addMe);
            ViewBag.myStack = progStack;
            return View("Index");
        }



    }
}