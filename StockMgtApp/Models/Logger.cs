using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StockMgtApp.Models
{
    public static class Logger
    {
        public static string Log(StockItem stock)
        {

            string Quantity; 
            string Stockbalance; 
            string IssueOut; 
            string Name; 
            string UnitPrice; 
            string Total; 
            string value; 
           

            Quantity = stock.Quantity.ToString();
            Stockbalance = stock.StockBalance.ToString();
            IssueOut = stock.IssueOut.ToString();
            Name = stock.StockName;
            UnitPrice = stock.Unitprice.ToString();
            Total = stock.NewTotal.ToString();
            value = stock.Total.ToString();
           
            
            DateTime date = DateTime.Now;

            string newdata = string.Format($" Name: {Name}, \n Price: {UnitPrice}, \n  Quantity: {Quantity}, \n Issue: {IssueOut} \n Balance: {Stockbalance}, \n IssuedToDate:{Total} \n Date/Time: {date} \n, \n");

            
                var filepath = @"C:\Users\HP\Desktop\Log\Issue.csv";
                
                File.AppendAllText(filepath, newdata);
                

            return newdata;

        }
    }
}
