using System;
using System.ComponentModel.DataAnnotations;

namespace CRM_1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string NecComponents { get; set; } = null!;

        public float Price { get; set; }

        public int DiscountSize { get; set; }

        public float RateForSale { get; set; }

        public bool IsReadyToMake { get; set; }
    }
}

