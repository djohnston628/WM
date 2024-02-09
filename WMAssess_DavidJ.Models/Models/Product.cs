using System.ComponentModel.DataAnnotations;

namespace WMAssess_DavidJ.Models;
    public class Product
    {
        public string SKU { get; set; }

        [Required(ErrorMessage = "Product title is required")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Product BuyerId is required")]
        public string BuyerId { get; set; }
        
        public bool Active { get; set; }
    }