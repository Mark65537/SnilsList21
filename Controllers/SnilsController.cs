using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using SnilsList21.Data;

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
    }
}
