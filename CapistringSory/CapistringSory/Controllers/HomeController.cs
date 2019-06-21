using CapistringSory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapistringSory.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StringValue.resultList.Clear();
            return View();
        }

        public ActionResult Responde()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(FormCollection collection)
        {
            string inputString = collection["inputValue"];
            int stringLength = inputString.Length;
            string defaultValue = inputString;
            int step = 0;
            string uppercaseChar;

            while (step < stringLength)
            {
                uppercaseChar = inputString[step].ToString().ToUpper();
                inputString = inputString.Remove(step, 1).ToLower();
                inputString = inputString.Insert(step, uppercaseChar);
                step++;
                uppercaseChar.ToLower();
                StringValue.resultList.Add(inputString);
            }

            inputString = defaultValue;
            step = stringLength - 1;

            while (step > 0)
            {
                uppercaseChar = inputString[step].ToString().ToUpper();
                inputString = inputString.Remove(step, 1);
                inputString = inputString.Insert(step, uppercaseChar);
                step--;
                uppercaseChar.ToLower();
                StringValue.resultList.Add(inputString);
            }

            inputString = defaultValue;
            step = 0;

            while (step < stringLength)
            {
                uppercaseChar = inputString[step].ToString().ToUpper();
                inputString = inputString.Remove(step, 1);
                inputString = inputString.Insert(step, uppercaseChar);
                step++;
                uppercaseChar.ToLower();
                StringValue.resultList.Add(inputString);
            }
            return RedirectToAction("Responde", "Home");
        }
    }
}