using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace atmnet
{
    public class Home : Controller
    {
        private readonly connect _connect;
        public static int id;

        public Home(connect connect)
        {
            _connect = connect;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult check(string pass)
        {
            var a = _connect.accounts.Where(b => b.ppassword == pass).SingleOrDefault();
            id=a.id;
            if (a!=null)
            {
            return RedirectToAction("login");
            }
            return RedirectToAction("Index");

        }
        public IActionResult bardasht(string credit)
        {
          

            return View();
        }
        public IActionResult bardashtkon(string mablagh)
        {
            var x =_connect.accounts.Where(a =>a.id==id).SingleOrDefault();
            if (x.credit>= int.Parse(mablagh))
            {
               x.credit=x.credit- int.Parse(mablagh);
               _connect.accounts.Update(x);
               _connect.SaveChanges();
            }
            return RedirectToAction("login");
        }

       
        
        public IActionResult login()
        {
            return View();
        }
        public IActionResult mojoudi()
        {
             var x =_connect.accounts.Where(a =>a.id==id).SingleOrDefault();
             ViewBag.m=x.credit;
            return View();
        }
        public IActionResult taghir()
        {
        


            return View();
        }
        public IActionResult taghirkon(string pass)
        {
             var x =_connect.accounts.Where(a =>a.id==id).SingleOrDefault();
             x.ppassword=pass;
             _connect.accounts.Update(x);
             _connect.SaveChanges();
             
            return RedirectToAction("index");
        }

        

    }

}