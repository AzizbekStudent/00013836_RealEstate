using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    // Student ID: 00013836
    public class Apartment
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "HouseTitle cannot be empty")]
        public string? HouseTitle { get; set; }

        [Required(ErrorMessage = "Description cannot be empty")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Area cannot be empty")]
        public double? Area { get; set; }

        [Required(ErrorMessage = "Price cannot be empty")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "CompletionDate cannot be empty")]
        public DateTime? CompletionDate { get; set; }

        [Required(ErrorMessage = "IsForRent cannot be empty")]
        public bool? IsForRent { get; set; } = false;

        // Foreign key for address entity
        public int? LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location? Location_ { get; set; }

        // Foreign key for category entity
        public int? VendorId { get; set; }

        [ForeignKey("CategoryId")]
        public Vendor? Vendor_ { get; set; }
    }
}
