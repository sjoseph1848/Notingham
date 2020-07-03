using System;
using System.Collections.Generic;
using System.Text;

namespace RobinTrack.EFModels
{
    public class IncomeStatementEF
    {
        public DateTime IncomeStatementDate { get; set; }
        public string Symbol { get; set; }
        public DateTime FillingDate { get; set; }
        public DateTime AcceptedDate { get; set; }
        public string Period { get; set; }
        public long Revenue { get; set; }
        public long CostofRevenue { get; set; }
        public long GrossProfit { get; set; }
        public decimal GrossProfitRatio { get; set; }
        public long ResearchAndDevelopmentExpense { get; set; }
        public long GeneralAndAdministrativeExpenses { get; set; }
        public long SellingAndMarketExpeneses { get; set; }
        public long OtherExpenses { get; set; }
        public long OperatingExpenses { get; set; }
        public long CostAndExpenses { get; set; }
        public long InterestExpenses { get; set; }
        public long DepreciationAndAmortization { get; set; }
        public long Ebitda { get; set; }
        public decimal EbitdaRatio { get; set; }
        public long OperatingIncome { get; set; }
        public long TotalOtherIncomeExpensesNet { get; set; }
        public long IncomeBeforeTax { get; set; }
        public decimal IncomeBeforeTaxRatio { get; set; }
        public long IncomeTaxExpense { get; set; }
        public long NetIncome { get; set; }
        public decimal NetIncomeRatio { get; set; }
        public decimal EPS { get; set; }
        public decimal EpsDiluted { get; set; }
        public long WeightedAverageShsOut { get; set; }
        public long WeightedAverageShsOutDil { get; set; }
        public string Link { get; set; }
        public string FinalLink { get; set; }

    }
}
