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
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        static Dictionary<int,String> progDictionary = new Dictionary<int, String>();

       
        public ActionResult Index()
        {
            ViewBag.myDictionary = progDictionary;
            return View();
        }
        //Add one item to Dictionary
        public ActionResult AddOneItemToDictionary()
        {
            progDictionary.Add((progDictionary.Count() + 1), "New Entry " + (progDictionary.Count() + 1));
            ViewBag.myDictionary = progDictionary;
            return View("Index");
        }
        //Add many items to Dictionary
        public ActionResult AddManyItemsToDictionary()
        {
            progDictionary.Clear();
            string addMe = "";
            while (progDictionary.Count() < 2001)
            {
                addMe = "New Entry " + progDictionary.Count();
                progDictionary.Add(progDictionary.Count(), addMe);
            }
            ViewBag.myDictionary = progDictionary;
            return View("Index");
        }
        //Display Dictionary
        public ActionResult DisplayDictionary()
        {
            ViewBag.myDictionary = progDictionary;
            return View("Index");
        }
        //Delete item from Dictionary
        public ActionResult DeleteFromDictionary()
        {
            bool isFound = false;
            string itemToDelete = Request.Form["ItemToDelete"];

            foreach(KeyValuePair<int, string> Dict in progDictionary)
            {
                if(Dict.Value == itemToDelete)
                {
                    isFound = true;
                    progDictionary.Remove(Dict.Key);
                }
                else
                {
                    isFound = false;
                }
            }
            if (isFound)
            {               
                ViewBag.myDictionary = progDictionary;
                return View("Index");
            }
            else
            {
                ViewBag.Output = "Sorry, the item you are looking for does not exist. Please try again";
                return View();
            }
        }
        //Method to Clear Dictionary
        public ActionResult ClearDictionary()
        {
            progDictionary.Clear();
            ViewBag.myDictionary = progDictionary;
            return View("Index");
        }

        //Method to search for item in Dictionary
        public ActionResult SearchDictionary()
        {
            bool isFound = false;
            string foundIt = "";
            int position = 0;
            //Loop through Dictionary to find the element
            string findMe = Request.Form["findMe"];
            foreach (KeyValuePair<int, string> element in progDictionary)
            {
                if (element.Value == findMe)
                {
                    isFound = true;
                    foundIt = element.Value;
                    position = progDictionary.Count();

                }
            }
            if (!isFound)
            {
                ViewBag.Output = "Sorry, the item you are looking for is not in the Dictionary.";
            }
            else
            {
                ViewBag.Output = foundIt + " was in position " + position + " of the Dictionary.";
            }
            return View();
        }
        public ActionResult AddCustomItem()
        {
            string addMe = "";
            addMe = Request.Form["addMe"];
            progDictionary.Add((progDictionary.Count()+1), addMe);
            ViewBag.myDictionary = progDictionary;
            return View("Index");
        }
    }
}