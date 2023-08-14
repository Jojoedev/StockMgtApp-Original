using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace StockMgtApp.Pages.Logic
{
    [Authorize]
    public class IssueModel : PageModel
    {
        private readonly DatabaseContext _Context;
        public IssueModel(DatabaseContext context)
        {
            _Context = context;
        }

        [BindProperty]
        public StockItem stockItem { get; set; }
        


        public ActionResult OnGet(int? id)
        {
            if(id != null)
            {
                //StockItem = (from n in _Context.STOCKMGT
                //           where n.Id == id
                //         select n).FirstOrDefault();

                stockItem = _Context.STOCKMGT.Include(x => x.Category).FirstOrDefault(n => n.Id == id);

                //Clears Issue cell each time a new issue request is made.
                stockItem.IssueOut = 0;
               
            }
            // return RedirectToAction("/Logic/List");
            return Page();
        }

        public ActionResult OnPost(StockItem stockItem)
        {
            
            CheckReOrderLevel(); //Validate availability of the requested stock
            
            ConfirmQty(); //Confirm available quantity

            if (ModelState.IsValid)
            {
                
               /* _Context.Entry(stockItem).Property(x => x.StockName).IsModified = false;*/
                _Context.Entry(stockItem).Property(x => x.IssueOut).IsModified = true;
                /*_Context.Entry(stockItem).Property(x => x.Unitprice).IsModified = false;
                _Context.Entry(stockItem).Property(x => x.StockBalance).IsModified = false;
                _Context.Entry(stockItem).Property(x => x.NewTotal).IsModified = false;*/


                var QtyIssueOut = stockItem.IssueOut;
                var Purchaseqty = stockItem.Quantity;
                var IssOutQty = Purchaseqty - QtyIssueOut;

                //stockItem.StockBalance += IssOutQty;
                stockItem.NewTotal += QtyIssueOut;

                if (stockItem.NewTotal == 0)
                {
                    stockItem.StockBalance += IssOutQty;
                }
                else
                {
                    stockItem.StockBalance = Purchaseqty - stockItem.NewTotal;
                }

                
                
                Logger.Log(stockItem); //Creating .csv file history on every issue operation.

                //Logger.SetAction("Issue");
                _Context.SaveChanges();
                return RedirectToPage("/Logic/List");
            }
            return Page();
        }

        public void ConfirmQty()
        {        
            
                var StockBal = stockItem.Quantity - stockItem.NewTotal;
                if (stockItem.Quantity < stockItem.IssueOut || stockItem.IssueOut > StockBal)
                {
                    throw new Exception("Error, Issue quantity cannot be more than avaliable quantity");
                }    
            
        }

        public string CheckReOrderLevel()
        {
            
            var msg = ("The stock quantity has reached Re-Order Level");
            var ReOderLevel = 3;
            var StockBal = stockItem.Quantity - stockItem.NewTotal;
            if(StockBal <= ReOderLevel)
            {
                return msg;
            }
            return null;
        }
            
        
    }
}
