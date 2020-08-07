using CPRG214.AssetManager.Data;
using CPRG214.AssetManager.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.AssetManager.BLL
{
    public class AssetsManager
    {
        // get list of all assets stored in AssetContext
        public static List<Asset> GetAll()
        {
            var context = new AssetContext();
            var assets = context.Assets.Include(a => a.AssetType).ToList();
            return assets;
        }

        // get a list of all assets of a given asset type
        public static List<Asset> GetAllByAssetType(int id)
        {
            var context = new AssetContext();
            var assets = context.Assets.
                Where(a => a.AssetTypeId == id).
                Include(a => a.AssetType).ToList();
            return assets;
        }

        // add an asset to the db
        public static void Add(Asset asset)
        {
            var context = new AssetContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }
    }
}
