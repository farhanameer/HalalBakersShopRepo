using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalalBakersShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace HalalBakersShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName);
            return View(categories);
        }
    }
}
