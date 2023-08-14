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
        public int? ItemCategoryId  { get; set; }
        public virtual ItemCategory Category { get; set; }
       

        [Display(Name = "Quantity")]
        [Required(ErrorMessage ="Enter product quantity")]
        public decimal Quantity { get; set; }
        
        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "Enter price")]
        public decimal Unitprice { get; set; }

        public string Description { get; set; }

        [Display(Name = "Total Value (N)")]
        public decimal Total { get; set; }

        
        [Display(Name = "Total Issued Out")]
        public decimal IssueOut { get; set; }

        
        [Display(Name = "Stock Balance")]
        public decimal StockBalance { get; set; }

        
        [Display(Name = "New Total")]
        public decimal NewTotal { get; set; }



        
    }
    
}
