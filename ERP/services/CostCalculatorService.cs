using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MyApp.Services
{
    public class CostCalculatorService
    {
        public decimal CalculateTotalCost(int totalUnits, decimal unitCost, decimal unitSellingPrice)
        {
            if (totalUnits < 0 || unitCost < 0)
            {
                throw new ArgumentException("Total units and unit cost cannot be negative.");
            }

            return totalUnits * unitCost;
        }

        public decimal CalculateProfit(int totalUnits, decimal unitCost, decimal unitSellingPrice)
        {
            if (totalUnits < 0 || unitCost < 0 || unitSellingPrice < 0)
            {
                throw new ArgumentException("Total units, unit cost, and unit selling price cannot be negative.");
            }

            decimal totalCost = totalUnits * unitCost;
            decimal totalRevenue = totalUnits * unitSellingPrice;

            return totalRevenue - totalCost;
        }

        public decimal CalculateMargin(decimal unitCost, decimal unitSellingPrice)
        {
            if (unitCost < 0 || unitSellingPrice < 0)
            {
                throw new ArgumentException("Unit cost and unit selling price cannot be negative.");
            }

            if (unitSellingPrice == 0)
            {
                return 0;
            }

            return (unitSellingPrice - unitCost) / unitSellingPrice;
        }
    }
}
