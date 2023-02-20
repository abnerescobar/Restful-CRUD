namespace Delivery.Exceptions
{
    public class NumberBooksLoanException : ApplicationException
    {
        public NumberBooksLoanException(string customerName) : base($"{customerName} cannot increment more the loan limit")
        {

        }
    }
}
