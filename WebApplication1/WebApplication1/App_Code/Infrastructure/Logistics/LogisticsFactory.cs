using System;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure.Logistics
{
    public class LogisticsFactory
    {
        public static ILogistics CreateLogistics(Product product, string logisticsSelectedValue)
        {
            if ("1".Equals(logisticsSelectedValue))
            {
                // 計算
                return new BlackCat() {ShipProduct = product};
            }
            else if ("2".Equals(logisticsSelectedValue))
            {
                return new Hsinchu() {ShipProduct = product};
            }
            else if ("3".Equals(logisticsSelectedValue))
            {
                return new PostOffice() {ShipProduct = product};
            }

            throw new ArgumentException("No Match LogisticsFactory");
        }
    }
}