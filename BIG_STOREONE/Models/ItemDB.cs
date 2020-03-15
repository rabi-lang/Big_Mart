﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIG_STOREONE.Models
{
    public static class ItemDB
    {
        public static List<tblProduct> GetAllSpecialItem()
        {
            using (var context = new eveningDBEntities())
            {
                return context.tblProducts.OrderByDescending(e=>e.ProductId).Where(s => s.IsSpecial == true).Take(8).ToList();
            }
        }
        public static List<tblProduct> GetAllItems()
        {
            using (var context = new eveningDBEntities())
            {
                return context.tblProducts.Take(8).ToList();
            }
        }
    }
}