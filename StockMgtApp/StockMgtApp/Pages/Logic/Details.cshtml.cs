using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.Logic
{
    public class EditModel : PageModel
    {
        private readonly DatabaseContext _Context;

        public StockItem stockItem { get; set; }
        public EditModel(DatabaseContext context)
        {
            _Context = context;
        }
        public void OnGet(int? id)
        {
            if(id != null)
            {
                //stockItem = (from n in _Context.STOCKMGT
                //           where n.Id == id
                //         select n).FirstOrDefault();
                stockItem = _Context.STOCKMGT.FirstOrDefault(x => x.Id == id);
                stockItem = stockItem;
            }
         
        }
    }
}
