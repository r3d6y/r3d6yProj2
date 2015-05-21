using restMVC4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restMVC4.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IService services;

        public BaseController(IService services)
        {
            this.services = services;
        }
    }
}
