using ProductManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductManagement.Data.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {

        private ProductContext _productContext;

        public ProductController()
        {
            _productContext = new ProductContext();
        }

        
        public IHttpActionResult GetAllProducts(bool includeSuppliers = false)
        {
            try
            {
                var productList = _productContext.Products.ToList();
                if (productList != null)
                    return Ok(productList);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult GetSingleProduct(int productId)
        {
            try
            {
                var product = _productContext.Products.Where(p => p.Id == productId).FirstOrDefault();
                            
                                
                if (product != null)
                    return Ok(product);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IHttpActionResult GetAllSuppliers(int id)
        {
            try
            {
                var supplierList = _productContext.Suppliers;


                if (supplierList != null)
                    return Ok(supplierList);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }


        public IHttpActionResult PostProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productContext.Products.Add(product);
                    _productContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult PutProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var productFound= _productContext.Products.Where(p => p.Id == product.Id).FirstOrDefault();
                    productFound.Name = product.Name;
                    productFound.LaunchDate = product.LaunchDate;
                    productFound.PackingType = product.PackingType;
                    productFound.SupplierId = product.SupplierId;
                    _productContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {

                var product = _productContext.Products.Where(p => p.Id == id).FirstOrDefault();
                if (product != null)
                {
                    _productContext.Products.Remove(product);
                    _productContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
