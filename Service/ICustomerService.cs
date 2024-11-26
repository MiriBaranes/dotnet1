using dotnet1.Dto;
using dotnet1.Entity;

namespace dotnet1.Service{
    public interface ICustomerService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<Customer> AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int id);
    Task<Customer?> GetCustomerByUserIdAsync(string userId);
    Task<int?> GetCustomerIdByUserIdAsync(string userId);
   
}

}