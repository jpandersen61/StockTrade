﻿using System.Collections.Generic;

namespace StockTrade
{
    /// <summary>
    /// A very small class, just containing a simple log
    /// for stock trading transactions
    /// </summary>
    public class TradeLog
    {
        public static List<string> Log = new List<string>();
        public static void PrintTradeLog()
        { 
            foreach(var l in Log)
            {
                System.Console.WriteLine(l);
            }
        }
    }
}