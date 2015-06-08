using restMVC4.Models;
using restMVC4.Repositories;
using restMVC4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BaseRepository<CategoryProducts> categoryRepository;

        public IEnumerable<CategoryProducts> GetCategories()
        {
            return categoryRepository.ToList();
        }
    }
}