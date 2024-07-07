using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWeb.DataAccess.Data;
using EcommerceWeb.Models;
using EcommerceWeb.Models.Models;
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
        public IActionResult Search()
        {
            List<SearchCategory> searches = _dbcontext.searchCategories.ToList();
            return View(searches);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display order cannot be same as Name");
            }

            //if(obj.Name!=null&& obj.Name.ToLower()=="test")
            //{
            //    ModelState.AddModelError("", "Test is an Invalid Name Value");
            //}
            if (ModelState.IsValid)
            {
                _dbcontext.Categories.Add(obj);
                _dbcontext.SaveChanges();
                TempData["success"] = "Category Added Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _dbcontext.Categories.Find(id);//Find returns the value of primary key;id is the primary key.
            //Category? categoryFromDb1 = _dbcontext.Categories.FirstOrDefault(u => u.Id == id);//passing value is not primary key
            //Category? categoryFromDb2 = _dbcontext.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Display order cannot be same as Name");
            //}

            //if(obj.Name!=null&& obj.Name.ToLower()=="test")
            //{
            //    ModelState.AddModelError("", "Test is an Invalid Name Value");
            //}
            if (ModelState.IsValid)
            {
                _dbcontext.Categories.Update(obj);
                _dbcontext.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _dbcontext.Categories.Find(id);//Find returns the value of primary key;id is the primary key.
            //Category? categoryFromDb1 = _dbcontext.Categories.FirstOrDefault(u => u.Id == id);//passing value is not primary key
            //Category? categoryFromDb2 = _dbcontext.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Display order cannot be same as Name");
            //}

            //if(obj.Name!=null&& obj.Name.ToLower()=="test")
            //{
            //    ModelState.AddModelError("", "Test is an Invalid Name Value");
            //}
            Category? deleteCategoryId = _dbcontext.Categories.Find(id);
            if (deleteCategoryId == null)
            {
                return NotFound();
            }
            _dbcontext.Categories.Remove(deleteCategoryId);
            _dbcontext.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> SearchList(string searchString)
        {
            var subjects = from c in _dbcontext.Categories
                           select c;
            if (!string.IsNullOrEmpty(searchString))
                {
                    subjects = subjects.Where(s => s.Name!.Contains(searchString));
                return View("Search");
            }
            TempData["success"] = "Please Select a Category";

            return RedirectToAction("Index");
            
            //if(obj.Name!=null&& obj.Name.ToLower()=="test")
            //{
            //    ModelState.AddModelError("", "Test is an Invalid Name Value");
            //}
            //if (ModelState.IsValid)
            //{
            //    _dbcontext.Categories.Add(obj);
            //    _dbcontext.SaveChanges();
            //    TempData["success"] = "Category Added Successfully";
            //    return RedirectToAction("Index");
            //}
           // return View();
        }
    }
}