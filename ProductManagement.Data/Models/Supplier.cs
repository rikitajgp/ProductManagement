using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Data.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool SupplierAvailable { get; set; }
    }
}