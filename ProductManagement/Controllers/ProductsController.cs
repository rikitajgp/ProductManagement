using ProductManagement.Data.Models;
using ProductManagement.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Controllers
{
    [Log]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {

            
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product?includeSuppliers=" + false).Result;
            throw new Exception("Something happened");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return View("NotFound");
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //    return ("");
            else
            {
                var model = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                return View(model);
            }
        }

        public ActionResult Create()
        {
            int id = 0;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product/" + id).Result;
            var model = new Product();

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return View("NotFound");
            }
            else
            {
                var SupplierList = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
                model.Suppliers = SupplierList.ToSelectListItems(-1);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            HttpResponseMessage response;
            if (ModelState.IsValid)
            {
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", product).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
                //else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                //{
                //}
            }

            int id = 0;
            response = GlobalVariables.WebApiClient.GetAsync("Product/" + id).Result;
            var SupplierList = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
            product.Suppliers = SupplierList.ToSelectListItems(-1);
            return View(product);
        }


        public ActionResult Edit(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product?productId=" + id).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return View("NotFound");
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //    return ("");
            else
            {
                var model = response.Content.ReadAsAsync<Product>().Result;
                int idFake = 0;
                response = GlobalVariables.WebApiClient.GetAsync("Product/" + idFake).Result;
                var SupplierList = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
                model.Suppliers = SupplierList.ToSelectListItems(-1);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            HttpResponseMessage response=null;
            if (!ModelState.IsValid)
            {
                int idFake = 0;
                response = GlobalVariables.WebApiClient.GetAsync("Product/" + idFake).Result;
                var SupplierList = response.Content.ReadAsAsync<IEnumerable<Supplier>>().Result;
                product.Suppliers = SupplierList.ToSelectListItems(-1);
                return View(product);
            }

            response = GlobalVariables.WebApiClient.PutAsJsonAsync("Product", product).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)            
                return View("NotFound");           

            else if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
              return  RedirectToAction("Index");
            }
            return null;
        }

        public ActionResult Details(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product?productId=" + id).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return View("NotFound");
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //    return ("");
            else
            {
                var model = response.Content.ReadAsAsync<Product>().Result;                
                return View(model);
            }
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product?productId=" + id).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return View("NotFound");
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //    return ("");
            else
            {
                var model = response.Content.ReadAsAsync<Product>().Result;                
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id,bool isDelete=true)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Product?id=" + id).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return View("NotFound");
            //else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //    return ("");
            else
            {

                return RedirectToAction("Index");
            }
        }
    }
}