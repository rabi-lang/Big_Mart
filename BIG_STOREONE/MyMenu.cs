using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIG_STOREONE.Models
{
    public class MyMenu
    {
        public static List<tblCategory> GetMenus()
        {
            using (var context = new eveningDBEntities())
            {
                return context.tblCategories.ToList();
            }
        }
      
    }
}