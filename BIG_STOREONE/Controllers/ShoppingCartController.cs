using BIG_STOREONE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIG_STOREONE.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        eveningDBEntities _db = new eveningDBEntities();
        public ActionResult AddToCart(tblProduct tbl)
        {
            if (Session["cart"] == null)
            {
                List<tblProduct> li = new List<tblProduct>();

                li.Add(tbl);
                Session["cart"] = li;
                ViewBag.cart = li.Count();


                Session["count"] = 1;


            }
            else
            {
                List<tblProduct> li = (List<tblProduct>)Session["cart"];
                li.Add(tbl);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return View();


        }
    }
}