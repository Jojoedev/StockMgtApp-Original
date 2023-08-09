using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockMgtApp.Models
{
    public class StockItem
    {

        [Key]
        public int Id { get;  set; }

       /* [Display(Name = "Date")]
        public DateTime DateOfReceipt { get; set; }*/

        [Required(ErrorMessage ="Enter Product Name")]
        [Display(Name = "Stock Name")]
        public string StockName { get; set; }
        //public Category Category { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage ="Enter product quantity")]
        public decimal Quantity { get; set; }
        
        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "Enter price")]
        public decimal Unitprice { get; set; }

        [Display(Name = "Total Value (N)")]
        public decimal Total { get; set; }

        [Display(Name = "Total Issued Out")]
        public decimal IssueOut { get; set; }

        [Display(Name = "Stock Balance")]
        public decimal StockBalance { get; set; }

        [Display(Name = "New Total")]
        public decimal NewTotal { get; set; }



        /*public int StockId { get; set; }
        [ForeignKey("StockId")]
        public StockHistory StockHistory { get; set; }*/

    }
    
}
