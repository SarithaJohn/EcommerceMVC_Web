using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWeb.Data;
using EcommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;
        public CategoryController(ApplicationDbContext context)
        {
            _dbcontext = context;
        }
        public IActionResult Index()
        {
            //var objCategoryList = _dbcontext.Categories.ToList();
            List<Category> objCategoryList = _dbcontext.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            _dbcontext.Categories.Add(obj);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}