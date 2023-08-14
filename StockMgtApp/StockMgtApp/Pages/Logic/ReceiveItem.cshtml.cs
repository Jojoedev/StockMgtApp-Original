using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.Logic
{
    public class CreateModel : PageModel
    {
       public readonly DatabaseContext _Context;
        private readonly ILogger _logger;
        
        public CreateModel(DatabaseContext context, ILogger<CreateModel> logger)
        {
            _Context = context;
            _logger = logger;
            
        }

        [BindProperty]
        public StockItem stockItem { get; set; }

        public SelectList Items { get; set; }

        public ActionResult OnGet()
        {
            Items = new SelectList(_Context.ItemCategories.ToList(), "Id", "Name");
            return Page();
        }

        
        public ActionResult OnPost(StockItem stockItem)
        {
            //Logger.Log(stockItem);
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

                //Logger.Log(stockItem);
        //        Logger.SetAction("Issue");

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
