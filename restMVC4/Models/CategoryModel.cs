using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Models
{
    public class CategoryModel
    {
        public CategoryModel()
        {

        }

        public CategoryModel(CategoryProducts model)
        {
            Id = model.IdCategory;
            Title = model.TitleCategory;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}