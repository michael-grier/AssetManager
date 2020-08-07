using CPRG214.AssetManager.Data;
using CPRG214.AssetManager.Domain;
using System.Collections;
using System.Linq;

namespace CPRG214.AssetManager.BLL
{
    public class AssetTypesManager
    {
        // get all asset types as kvps
        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetContext();
            var types = context.AssetTypes.Select(t => new
            {
                Value = t.Id,
                Text = t.Name
            }).ToList();
            return types;
        }

        // add an asset type to the db
        public static void Add(AssetType type)
        {
            var context = new AssetContext();
            context.AssetTypes.Add(type);
            context.SaveChanges();
        }
    }
}
