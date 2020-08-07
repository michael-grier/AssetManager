using System.Collections.Generic;
using CPRG214.AssetManager.BLL;
using CPRG214.AssetManager.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.AssetManager.Presentation.Controllers
{
    public class AssetTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // generate view to add new asset types
        public IActionResult Create()
        {
            // create collection of asset types, then store collection in ViewBag
            var list = new List<AssetType>();
            ViewBag.AssetTypes = list;

            return View();
        }

        // add new asset to database
        [HttpPost]
        public IActionResult Create(AssetType type)
        {
            // if new asset type is successfully added to db, redirect to main page. if not, reload current view
            try
            {
                AssetTypesManager.Add(type);
                return RedirectToAction("Search", "Asset");
            }
            catch
            {
                return View();
            }
        }
    }
}
