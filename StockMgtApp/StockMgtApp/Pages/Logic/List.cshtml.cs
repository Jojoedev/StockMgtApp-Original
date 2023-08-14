using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StockMgtApp.Models;


namespace StockMgtApp.Pages.Logic
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _Context;

        
        public IndexModel(DatabaseContext context)
        {
            _Context = context;
        }

        [BindProperty]
        public ItemCategory itemCategory { get; set; }
        public List<StockItem> StockItem { get; set; }

        //public StockItem StockItem { get; set; }
        public void  OnGet()
        {
           // StockItem = (from emp in _Context.STOCKMGT select emp).ToList<ItemCategory>();
            StockItem = _Context.STOCKMGT.Include(s => s.Category).ToList();
            //return StockItem;
        }
    }
}
