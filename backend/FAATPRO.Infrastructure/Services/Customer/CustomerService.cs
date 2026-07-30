using FAATPRO.Application.Features.Customers.DTOs;
using FAATPRO.Application.Features.Customers.Interfaces;

using CustomerEntity = FAATPRO.Domain.Entities.Customer;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.Customer;


public class CustomerService : ICustomerService
{

    private readonly ApplicationDbContext _context;


    public CustomerService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<CustomerDto>> GetAllAsync()
    {

        return await _context.Customers

            .Select(x => new CustomerDto
            {
                Id = x.Id,

                Name = x.Name,

                Email = x.Email,

                Phone = x.Phone,

                Address = x.Address,

                IsActive = x.IsActive,

                CreatedAt = x.CreatedAt

            })

            .ToListAsync();

    }





    public async Task<CustomerDto?> GetByIdAsync(
        Guid id)
    {

        var customer =
            await _context.Customers
            .FirstOrDefaultAsync(
                x => x.Id == id);



        if(customer == null)
            return null;




        return new CustomerDto
        {
            Id = customer.Id,

            Name = customer.Name,

            Email = customer.Email,

            Phone = customer.Phone,

            Address = customer.Address,

            IsActive = customer.IsActive,

            CreatedAt = customer.CreatedAt
        };

    }





    public async Task<CustomerDto> CreateAsync(
        CreateCustomerRequest request)
    {


        var customer = new CustomerEntity
        {

            Id = Guid.NewGuid(),

            Name = request.Name,

            Email = request.Email,

            Phone = request.Phone,

            Address = request.Address,

            IsActive = true,

            CreatedAt = DateTime.UtcNow

        };



        _context.Customers.Add(customer);


        await _context.SaveChangesAsync();




        return new CustomerDto
        {

            Id = customer.Id,

            Name = customer.Name,

            Email = customer.Email,

            Phone = customer.Phone,

            Address = customer.Address,

            IsActive = customer.IsActive,

            CreatedAt = customer.CreatedAt

        };

    }





    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var customer =
            await _context.Customers
            .FirstOrDefaultAsync(
                x => x.Id == id);



        if(customer == null)
            return false;



        _context.Customers.Remove(customer);


        await _context.SaveChangesAsync();



        return true;

    }

}