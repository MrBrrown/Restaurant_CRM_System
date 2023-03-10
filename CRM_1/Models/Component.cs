using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CRM_1.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Category { get; set; } = null!;

        public int Amount { get; set; }

        public bool IsChecked { get; set; } = true;
    }
}

