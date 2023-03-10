using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM_1.Models;
using CRM_1.Services.ComponentRep;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRM_1.Pages
{
    public class StockPageModel : PageModel
    {
        [BindProperty]
        public List<string> CategoryCheck { get; set; }

        private readonly IComponentRepository db;

        public IEnumerable<Component> Components { get; set; }

        public List<string> Categories { get; set; }


        public StockPageModel(IComponentRepository db)
        {
            this.db = db;
        }

        public IActionResult OnPostUpdateCategories()
        {
            db.SetCheck(CategoryCheck);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdate(int id)
        {
            Component component = new Component()
            {
                Id = id,
                Name = Request.Form["Name"],
                Amount = Int32.Parse(Request.Form["Amount"]),
                Category = Request.Form["Category"]
            };

            db.Update(component);

            return RedirectToPage();
        }

        public IActionResult OnPostAdd()
        {
            Component component = new Component()
            {
                Id = db.GetLastComponentId() + 1,
                Name = Request.Form["Name"],
                Amount = Int32.Parse(Request.Form["Amount"]),
                Category = Request.Form["Category"],
                IsChecked = true
                
            };

            db.AddComponent(component);

            return RedirectToPage();
        }

        public IActionResult OnPostDelete(int id)
        {
            db.DeletComponentById(id);
            return RedirectToPage();
        }

        public void OnGet()
        {
            Categories = db.GetAllCategories();

            Components = db.GetComponents();

            Components = Components.OrderBy(x => x.Name);
        }
    }
}
