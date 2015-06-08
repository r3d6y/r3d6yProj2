using restMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryProducts> GetCategories();
    }
}