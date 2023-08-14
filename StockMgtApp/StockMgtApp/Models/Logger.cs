
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
        public static string ActionMethod { get; set; } 
        public static string SetAction(string operation)
        {
           
            if (operation == "Delete")
            {
                ActionMethod = "Delete";
            }
            else if (operation == "Issue")
            {
                ActionMethod = "Issue";
            }
            else if (operation == "Receive")
            {
                ActionMethod = "Receive";
            }
            return ActionMethod;
        }

        public static string Log(StockItem stockitem)
        {

            //string Name;
            string Quantity;
            string UnitCost;
            string TotalCost;
            string IssueOut;
            string Stockbalance;
            string CurrentBalance;


            //Name = stockitem.Category.Name;
            Quantity = stockitem.Quantity.ToString();
            UnitCost = stockitem.Unitprice.ToString();
            TotalCost = stockitem.Total.ToString();
            IssueOut = stockitem.IssueOut.ToString();
            Stockbalance = stockitem.StockBalance.ToString();
            CurrentBalance = stockitem.NewTotal.ToString();


            DateTime date = DateTime.Now;

            string newdata = string.Format($"Name: {stockitem.Category.Name} \n Quantity: {Quantity}, " +
                $"\n Cost/Unit: {UnitCost}," + $"\n Current Issue: {IssueOut} \n Stock Balance: {Stockbalance}, " +
                $"\n IssuedToDate:{CurrentBalance} \n Date/Time: {date} \n, \n");


            //Logger.SetAction("Delete");


            string Issu = "Issue";
            //string Del = "Delete";
            //  string Receive = "Receive";


            //var filepath = @"C:\Users\HP\Desktop\Log\Issue.csv";
            var filepath = $@"C:\Users\HP\Desktop\CSharp projects\StockMgtApp\StockMgtApp\StockMgtApp\wwwroot\Warehouse\{Issu}" + ".csv";

            File.AppendAllText(filepath, newdata);


            return newdata;

        }
    }
}
