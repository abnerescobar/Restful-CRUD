namespace Delivery.Models
{
    public record CustomerResponse
   (
        int Id,
        string Name,
        string PhoneNumber,
        string Email,
        string Address,
        bool Status
    );
}
