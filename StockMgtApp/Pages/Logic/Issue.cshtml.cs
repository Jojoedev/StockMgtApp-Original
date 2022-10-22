using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StockMgtApp.Models;

namespace StockMgtApp.Pages.Logic
{
    public class IssueModel : PageModel
    {
        private readonly DatabaseContext _Context;
        public IssueModel(DatabaseContext context)
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
                StockItem.IssueOut = 0;
               
            }
            // return RedirectToAction("/Logic/List");
            return Page();
        }

        public ActionResult OnPost(StockItem stockItem)
        {
            CheckReOrderLevel();
            ConfirmQty();
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

                _Context.SaveChanges();
                return RedirectToPage("/Logic/List");
                
            }
            return Page();
        }

     
        
        public void ConfirmQty()
        {
                  
                var StockBal = StockItem.Quantity - StockItem.NewTotal;
                if (StockItem.Quantity < StockItem.IssueOut)
                {
                    throw new Exception("Available stock cannot statisfy request ");

                }
                if (StockItem.IssueOut > StockBal)
                {
                    throw new Exception("Available stock is insufficient to meet request");
                }
            
                
    
        }

        public string CheckReOrderLevel()

        {
            var msg = ("The stock quantity has reached Re-Order Level");

            var ReOderLevel = 3;
            var StockBal = StockItem.Quantity - StockItem.NewTotal;
            if(StockBal <= ReOderLevel)
            {
                return msg;
            }
            return null;
        }
            
    }
}
