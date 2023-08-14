using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.ItemsLogic
{
    public class CreateItemModel : PageModel
    {
        private readonly DatabaseContext _Context;
        public CreateItemModel(DatabaseContext context)
        {
            _Context = context;
        }


        [BindProperty]
        public ItemCategory itemCategory { get; set; }
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost(ItemCategory itemCategory) 
        {
            CheckDuplication(itemCategory);
            if (ModelState.IsValid)
            {
                _Context.ItemCategories.Add(itemCategory);
                _Context.SaveChanges();
                return RedirectToPage("List");
            }
            return Page();
        }

        public void CheckDuplication(ItemCategory item)
        {
            var NewItem = _Context.ItemCategories.Where(x => x.Name == item.Name);

            if(NewItem.Any())
            {
                throw new Exception("Duplication error");
            }
            
        }
        
    }
}
