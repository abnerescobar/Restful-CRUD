namespace Delivery.Models
{
    public record UpdateCustomerRequest
    (
        int Id,
        string Name,
        string PhoneNumber,
        string Email,
        string Address,
        bool Status
    );

}
