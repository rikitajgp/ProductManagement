using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ProductManagement.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime LaunchDate { get; set; }

        [Required]
        public PackingType PackingType { get; set; }

        public Supplier Supplier { get; set; }

       

        [Required]
        public int SupplierId { get; set; }
        
        public IEnumerable<SelectListItem> Suppliers { get; set; }

        //public string SupplierName { get; set; }

    }

    
}