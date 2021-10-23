using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
            this.Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count { get => Portfolio.Count; }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && MoneyToInvest>stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

       public string SellStock(string companyName, decimal sellPrice)
        {
            Stock targetStock = Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (targetStock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice< targetStock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            Portfolio.Remove(targetStock);
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

      public  Stock FindStock(string companyName)
        {
            Stock targetStock = Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            return targetStock;
        }

        public Stock FindBiggestCompany()
        {
            Stock biggestStock = Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();

            return biggestStock;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

    }
}
