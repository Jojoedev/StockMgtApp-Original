using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMgtApp.Models
{
    public static class Logs
    {
        public static bool MyLog(this ItemCategory item, StockItem stockItem)
        {
            var stock = item.Name;
            return true;
                        
        }

    }
}
