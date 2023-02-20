using Microsoft.AspNetCore.Mvc;
using Mapster;

using Delivery.Entity;
using Delivery.Repositories.Interfaces;
using Delivery.Models;
using Delivery.Exceptions;

namespace Delivery.Controllers;

[ApiController]
[Route("api/customers")]


   public class CustomersController :ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CustomersController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository= customerRepository;
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> Get()
    {
        var Customers = await _customerRepository.GetAll();
        return Ok(Customers);
    }
    [HttpPost]
    public async Task<IActionResult>CreateCustomer([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {
       var customer = request.Adapt<Customer>();

       /* var customer = new Customer(request.Name,
             request.Email,
             request.PhoneNumber,
             request.Address
        );*/
        _customerRepository.Add(customer);

        _unitOfWork.SaveChangesAsync(cancellationToken);

        var response =customer.Adapt<CustomerResponse>();

        return CreatedAtAction(
            nameof(GetCustomerById),
            new {id = response.Id}, response);
    }
   [HttpPut("{id:int}")]
   public async Task<IActionResult> UpdateCustomer( int id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        if (request.Id != id)
        {
            throw new  BadRequestException("Body Id is not equal than Url Id");
        }
        var customer = await _customerRepository.GetCustomerById(id, cancellationToken);
        if (customer is null)
        {
           throw  new NotFoundException("Customer",id);
        }
        customer.ChangeName(request.Name);
        customer.ChangePhoneNumber(request.PhoneNumber);
        customer.ChangeEmail(request.Email);
        customer.ChangeAddress(request.Address);
        customer.ChangeStatus(request.Status);
        customer.IncrementCreditLimit(request.CreditLimit);
        customer.IncrementBookLoan(request.LoanLimit);

        _customerRepository.Update(customer);

        _unitOfWork.SaveChangesAsync(cancellationToken);

        return NoContent();

    }
   [HttpGet("{id:int}")]
   public async Task<IActionResult> GetCustomerById(int id,CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerById(id, cancellationToken);
        if(customer is null)
        {
          throw new  NotFoundException("Customer",id);
        }
        var response = customer.Adapt<CustomerResponse>();
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult>DeleteCustomer(int id,[FromBody] CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerById(id);
        if (customer is null)
        {
            NotFound("$Customer Not Fount With the Id {id}");
        }
        await _customerRepository.Delete(id);

        return Ok(customer);
    }

}
