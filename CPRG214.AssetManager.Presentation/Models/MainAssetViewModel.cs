using System.ComponentModel.DataAnnotations;

namespace CPRG214.AssetManager.Presentation.Models
{
    public class MainAssetViewModel
    {
        public string Description { get; set; }
        [Display(Name = "Asset Type")]
        public string AssetType { get; set; }
        [Display(Name = "Tag #")]
        public string TagNumber { get; set; }
        [Display(Name = "Serial #")]
        public string SerialNumber { get; set; }
    }
}
