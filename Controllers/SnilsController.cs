using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using SnilsList21.Data;
using SnilsList21.Models;

namespace SnilsList21.Controllers
{
    public class SnilsController : Controller
    {
        private readonly AppDBContext _appDBContext = new AppDBContext();
        public IActionResult Index()
        {
            var model = _appDBContext.SnilsSet.ToList();
            return View(model);
        }

        public ViewResult Create()
        {
            return View(new SnilsCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create( SnilsCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newSnils = new Snils
                {
                    Number = model.Number
                };

                TempData["Message"] = "СНИЛС успешно создан!";

                _appDBContext.Add(newSnils);
                _appDBContext.SaveChanges();

                return RedirectToAction("Index");
            }

            TempData["Message"] = "СНИЛС не может быть создана!";

            return View(model);
        }
    }
}
