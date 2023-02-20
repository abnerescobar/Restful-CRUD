namespace Delivery.Exceptions
{
    public class CreditLimitException : ApplicationException
    {
        public CreditLimitException(string customerName) : base($"{customerName} cannot increment more the credit limit")
        {

        }
    }
}
