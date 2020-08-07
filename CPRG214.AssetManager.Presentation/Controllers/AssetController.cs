using System.Collections;
using System.Linq;
using CPRG214.AssetManager.BLL;
using CPRG214.AssetManager.Domain;
using CPRG214.AssetManager.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.AssetManager.Presentation.Controllers
{
    public class AssetController : Controller
    {
        // call local service to get collection of assets as the viewmodel
        public IActionResult Index()
        {
            var assets = AssetsManager.GetAll();
            var viewModels = assets.Select(a => new MainAssetViewModel
            {
                Description = a.Description,
                AssetType = a.AssetType.Name,
                TagNumber = a.TagNumber,
                SerialNumber = a.SerialNumber
            }).ToList();
            return View(viewModels);
        }

        // generate a dropdown list populated with asset types
        protected IEnumerable GetAssetTypes()
        {
            //create collection of asset types as select list items 
            var assetTypes = AssetTypesManager.GetAsKeyValuePairs();
            var styles = new SelectList(assetTypes, "Value", "Text");

            // insert new list item for all asset types at index 0
            var list = styles.ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "All Types",
                Value = "0"
            });

            return list;
        }

        public IActionResult GetAssetsByType(int id)
        {
            return ViewComponent("AssetsByType", id);
        }

        // search for assets by type
        public IActionResult Search()
        {
            ViewBag.AssetTypes = GetAssetTypes();
            return View();
        }

        // filter assets by type
        public IActionResult FilteredAssets(int id)
        {
            // go the the asset manager, get all the assets of given asset type
            var filteredAssets = AssetsManager.GetAllByAssetType(id);
            var result = $"Asset Count: {filteredAssets.Count}";
            return Content(result);
        }

        // generate view to add new assets
        public IActionResult Create()
        {
            // call AssetTypesManager and get collection of KVP objects
            var assetTypes = AssetTypesManager.GetAsKeyValuePairs();
            // create collection of SelectListItems, then store collection in ViewBag
            var list = new SelectList(assetTypes, "Value", "Text");
            ViewBag.AssetTypeId = list;

            return View();
        }

        // add new asset to database
        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            // if new asset is successfully added to db, redirect to main page. if not, reload current view
            try
            {
                AssetsManager.Add(asset);
                return RedirectToAction("Search");
            }
            catch
            {
                return View();
            }
        }
    }
}
