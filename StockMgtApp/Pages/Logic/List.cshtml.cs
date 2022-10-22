using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.Logic
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _Context;

        public List<StockItem> StockItem { get; set; }
        public IndexModel(DatabaseContext context)
        {
            _Context = context;
        }
        
        public void OnGet()
        {
            var Stock = (from emp in _Context.STOCKMGT
                             select emp).ToList();
            StockItem = Stock; 
            
                    
        }
    }
}
