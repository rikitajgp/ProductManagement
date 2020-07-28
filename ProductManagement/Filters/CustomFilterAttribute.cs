using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagement.Filters
{
    public class CustomFilterAttribute :HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        { 
            
            Console.WriteLine("testing");
        }

        public virtual void DoSome()
        {
            throw new NotFiniteNumberException();
        }
    }
}