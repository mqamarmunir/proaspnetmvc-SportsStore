﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository productrepos)
        {
            repository = productrepos;
        }
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            return PartialView(categories);
        }
    }
}