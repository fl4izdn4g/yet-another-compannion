using Princess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Princess.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
            Mystery model = new Mystery();
            if (HttpContext.Request.Cookies.AllKeys.Contains("MYSTERY_SOLUTIONS"))
            {
                var cookieValue = HttpContext.Request.Cookies["MYSTERY_SOLUTIONS"].Value;
                string[] elements = cookieValue.Split(new char[] { '|' });
                
                for (int i = 0; i < elements.Length - 1; i++)
                {
                    string[] keyValue = elements[i].Split(new char[] { ':' });
                    switch(keyValue[0])
                    {
                        case "Clue1":
                            model.Clue1 = keyValue[1];
                            break;
                        case "Clue2":
                            model.Clue2 = keyValue[1];
                            break;
                        case "Clue3":
                            model.Clue3 = keyValue[1];
                            break;
                        case "Clue4":
                            model.Clue4 = keyValue[1];
                            break;
                        case "Clue5":
                            model.Clue5 = keyValue[1];
                            break;
                        case "Clue6":
                            model.Clue6 = keyValue[1];
                            break;
                        case "Clue7":
                            model.Clue7 = keyValue[1];
                            break;
                        case "Clue8":
                            model.Clue8 = keyValue[1];
                            break;
                        case "Clue9":
                            model.Clue9 = keyValue[1];
                            break;
                    }
                }
        
            }
       */
            var clues = new Dictionary<string, bool>();
            string[] keys = new string[] { "Clue1", "Clue2", "Clue3", "Clue4", "Clue5", "Clue6", "Clue7", "Clue8", "Clue9" };
            for (int i = 0; i < keys.Length; i++)
            {
                clues.Add(keys[i], false);
            }
            ViewBag.ClueValid = clues;




            // return View(model);
            return View();
        }

        [HttpPost]
        public ActionResult Index(Mystery model)
        {
            if (ModelState.IsValid)
            {
                Session["MYSTERY_OK"] = true;
                return RedirectToAction("Mystery", "Home");
            }

            var clues = new Dictionary<string, bool>();
            StringBuilder solutions = new StringBuilder();
            string[] keys = new string[] { "Clue1", "Clue2", "Clue3", "Clue4", "Clue5", "Clue6", "Clue7", "Clue8", "Clue9" };
            for (int i = 0; i < keys.Length; i++)
            {
                clues.Add(keys[i], false);
            }

            foreach (var key in ModelState.Keys)
            {
                if(ModelState[key].Errors.Count > 0)
                {
                    clues[key] = false;
                    solutions.AppendLine(key + ":");
                }
                else
                {
                    clues[key] = true;
                    solutions.AppendLine(key + ":" + ModelState[key].Value.AttemptedValue);
                }
            }
            ViewBag.ClueValid = clues;

            /*
            string cookieValue = solutions.ToString().Replace("\r\n", "|");
            HttpCookie cookie = new HttpCookie("MYSTERY_SOLUTIONS", cookieValue);
            cookie.Expires = DateTime.Now.AddYears(1);

            HttpContext.Response.Cookies.Add(cookie);
            */
            return View(model);
        }

        public ActionResult Mystery()
        {
            if(Session["MYSTERY_OK"] == null || (bool)Session["MYSTERY_OK"] == false) 
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult GimmeMyPrize()
        {
            if (Session["MYSTERY_OK"] == null || (bool)Session["MYSTERY_OK"] == false)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult GimmeMyPrize(GimmeMyPrize model)
        {
            if (ModelState.IsValid)
            {
                DateTime obecnie = DateTime.Now;
                string name = obecnie.Year.ToString() + obecnie.Month.ToString() + 
                              obecnie.Day.ToString() + obecnie.Hour.ToString() + obecnie.Minute.ToString() +
                              obecnie.Second.ToString() + ".txt";
                var dataFile = Server.MapPath("~/Content/" + name);
                System.IO.File.CreateText(dataFile);


                return RedirectToAction("YourPrize", "Home");
            }

            return View(model);
        }

        public ActionResult YourPrize()
        {
            if (Session["MYSTERY_OK"] == null || (bool)Session["MYSTERY_OK"] == false)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}