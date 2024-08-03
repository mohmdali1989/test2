namespace Accountant.Models
{
    public class combinedList//قايمه المجموعات المبالغ الماليه
    {
        public decimal PluraltrafficViolations { get; set; }
        public decimal Pluralexpenses { get; set; }
        public decimal PluralExpenses { get; set; }
        public decimal PluralFuelQuantity { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal PluralPrice { get; set; }

        public int Year { get; set; }
        public int Month { get; set; }
    }
}
