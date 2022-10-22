using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.Logic
{
    public class ModifyModel : PageModel
    {
        private readonly DatabaseContext _Context;
        public ModifyModel(DatabaseContext context)
        {
            _Context = context;
        }
        [BindProperty]
        public StockItem StockItem { get; set; } 
        public ActionResult OnGet(int? id)
        {
            if(id != null)
            {
                StockItem = (from n in _Context.STOCKMGT
                                 where n.Id == id
                                 select n).FirstOrDefault();
              var D = StockItem.NewTotal;
                
            }
            return Page();
        }
    


        public ActionResult OnPost(StockItem StockItem)
        {
            

            if (ModelState.IsValid)
            {
                   
                _Context.Entry(StockItem).Property(X => X.StockName).IsModified = true;
                _Context.Entry(StockItem).Property(X => X.Quantity).IsModified = true;
                _Context.Entry(StockItem).Property(X => X.Unitprice).IsModified = true;
                  _Context.Entry(StockItem).Property(X => X.NewTotal).IsModified = false;
                var b = StockItem.NewTotal;

                StockItem.StockBalance = StockItem.Quantity - StockItem.NewTotal;
                StockItem.Total = StockItem.Quantity * StockItem.Unitprice;
                
                _Context.SaveChanges();
            }
            return RedirectToPage("/Logic/List");
        }
    }
}
