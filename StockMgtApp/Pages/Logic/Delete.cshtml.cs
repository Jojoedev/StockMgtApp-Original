using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.Logic
{
    public class DeleteModel : PageModel
    {
       private readonly DatabaseContext _Context;
        public DeleteModel(DatabaseContext context)
        {
            _Context = context;
        }
        public ActionResult OnGet(int? id)
        {
            if(id != null)
            {
                var d = (from n in _Context.STOCKMGT
                         where n.Id == id
                         select n).FirstOrDefault();
                _Context.Remove(d);
                _Context.SaveChanges();
              
            }
            return RedirectToPage("/Logic/List");
        }
    }
}
