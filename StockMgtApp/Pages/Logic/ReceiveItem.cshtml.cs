using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.Logic
{
    public class CreateModel : PageModel
    {
       public readonly DatabaseContext _Context;
        [BindProperty]
        public StockItem stockItem { get; set; }

        public CreateModel(DatabaseContext context)
        {
            _Context = context;
            
        }
        public void OnGet(int id)
        {

        }
        
        public ActionResult OnPost(StockItem stockItem)
        {

            /*var emp = StockItem;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _Context.Add(emp);
            _Context.SaveChanges();

            return RedirectToPage("/Logic/List");*/

            /*var NewId = new Random().Next();*/
                        
            
            if (ModelState.IsValid)
            {
             var total = stockItem.Quantity * stockItem.Unitprice;
                stockItem.Total = total;
                stockItem.StockBalance = stockItem.Quantity;
                _Context.Add(stockItem);
                _Context.SaveChanges();
                return RedirectToPage("/Logic/List");
            }

            return Page();
        }

        /*public decimal TotalValue(StockItem stockItem)
        {
            var value =  stockItem.Quantity * stockItem.Unitprice;
            value += stockItem.Total;
            return value;
        }*/
        
    }
    
    
}
