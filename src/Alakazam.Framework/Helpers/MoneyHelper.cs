namespace Alakazam.Framework.Helpers
{
    public static class MoneyHelpers
    {
        public static Money CalculateTax(this Money money, sbyte taxRate)
        {
            return (money / 100) * taxRate;
        }
    }
}