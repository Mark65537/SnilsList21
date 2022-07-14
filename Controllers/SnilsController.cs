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
            TempData["Message"] = null;
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
                string Number = model.Number.Trim();
                if (Number.Length != 11 || !long.TryParse(Number, out long num))
                {
                    TempData["Message"] = "СНИЛС введен не корректно!";
                    return View(model);
                }                 

                var newSnils = new Snils
                {
                    Number = Number
                };


                if (_appDBContext.SnilsSet.Any(x => x.Number.Equals(Number)))
                {
                    TempData["Message"] = "СНИЛС не может быть создан так как уже существует!";
                    return View(model);
                }

                if (!testSnils(Number))
                {
                    TempData["Message"] = "СНИЛС не может быть создан так как контрольная сумма не валидна !";
                    return View(model);
                }

                _appDBContext.Add(newSnils);
                _appDBContext.SaveChanges();

                return RedirectToAction("Index");
            }

            TempData["Message"] = "СНИЛС не может быть создан!";

            return View(model);
        }

        private bool testSnils(string number)
        {
            //проверка на длину строк
            if (number.Length == 11)
            {
               
                string checknum = number.Substring(9);
                byte k = 9;
                int sum = 0;
                for (byte i=0;i<9;i++)
                {
                    sum += k * int.Parse(number[i].ToString());
                    k--;
                }

                if (sum<100)
                {
                    if (checknum.Equals(sum.ToString("00")))
                        return true;
                    else 
                        return false;
                }
                else if (sum==100 || sum==101)
                {
                    if (checknum.Equals("00"))
                        return true;
                    else
                        return false;
                }
                else
                {
                    int ost=sum % 101;
                    if (checknum.Equals(ost.ToString("00")))
                        return true ;
                    else if (ost == 100 && checknum.Equals("00"))
                        return true;
                    else
                        return false;

                }
            }
            return false;
        }
    }
}
