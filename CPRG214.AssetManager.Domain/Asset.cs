using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.AssetManager.Domain
{
    [Table("Asset")]
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        public string TagNumber { get; set; }
        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        // model is optional field
        [Display(Name = "Model (optional)")]
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        // navigation property
        public AssetType AssetType { get; set; }
    }
}
