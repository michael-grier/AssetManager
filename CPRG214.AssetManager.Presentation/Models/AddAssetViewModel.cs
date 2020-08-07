using CPRG214.AssetManager.Domain;
using System.ComponentModel.DataAnnotations;

namespace CPRG214.AssetManager.Presentation.Models
{
    public class AddAssetViewModel
    {
        [Required]
        public string TagNumber { get; set; }
        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Display(Name = "Model (optional)")]
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        public AssetType AssetType { get; set; }
    }
}
