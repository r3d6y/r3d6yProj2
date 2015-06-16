using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Models
{
    public class BasketKeyValueModel
    {
        public int id { get; set; }
        public int count { get; set; }
        public DishModel dish { get; set; }
        public BasketKeyValueModel()
        {

        }
    }
}