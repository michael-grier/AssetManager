using CPRG214.AssetManager.Domain;
using CPRG214.AssetManager.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.AssetManager.Presentation.Models;

namespace CPRG214.AssetManager.Presentation.ViewComponents
{
    // return only the assets associated with given AssetTypeId
    public class AssetsByTypeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> assets = null;

            if (id == 0)
            {
                assets = AssetsManager.GetAll();
            }
            else
            {
                assets = AssetsManager.GetAllByAssetType(id);
            }

            var asset = assets.Select(a => new MainAssetViewModel
            {
                Description = a.Description,
                AssetType = a.AssetType.Name,
                TagNumber = a.TagNumber,
                SerialNumber = a.SerialNumber
            }).ToList();

            return View(asset);
        }
    }
}
