using System;

#pragma warning disable 4014

namespace StockTrade
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Create a PulseGenerator object
            PulseGenerator thePulseGenerator = new PulseGenerator();

            // Create some Stock objects
            Stock s1 = new Stock("Google", 100, 200);
            Stock s2 = new Stock("Tesla", 500, 1000);
            Stock s3 = new Stock("Gamestop", 100, 200);

            // Create some StockTrader objects
            StockTrader st1 = new StockTrader("Hugo","Google", 150, false);

            // Update stock prices on every Pulse event
            thePulseGenerator.Pulse += s1.GenerateNewPrice;
            thePulseGenerator.Pulse += s2.GenerateNewPrice;
            thePulseGenerator.Pulse += s3.GenerateNewPrice;

            // Make sure StockTrader objects are notified when
            // the price of a stock changes
            s1.PriceChanged += st1.DoTrade;
            s2.PriceChanged += st1.DoTrade;
            s3.PriceChanged += st1.DoTrade;

            // Print out current stock prices on every Pulse event
            thePulseGenerator.Pulse += s1.PrintStockPrice;
            thePulseGenerator.Pulse += s2.PrintStockPrice;
            thePulseGenerator.Pulse += s3.PrintStockPrice;

            // Print out the entire Trade log on the LastPulse event
            thePulseGenerator.LastPulse += TradeLog.PrintTradeLog;

            // Start pulsing...
            thePulseGenerator.Start(200, 20);

            KeepConsoleWindowOpen();
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.ReadKey();
        }
    }
}
