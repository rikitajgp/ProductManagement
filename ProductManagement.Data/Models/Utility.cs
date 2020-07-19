using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Data.Models
{
    public static class Utility
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
             this IEnumerable<Supplier> suppliers, int selectedId)
        {
            return
                suppliers.OrderBy(supplier => supplier.Name)
                      .Select(supplier =>
                          new SelectListItem
                          {
                              Selected = (supplier.Id == selectedId),
                              Text = supplier.Name,
                              Value = supplier.Id.ToString()
                          });
        }
    }
}