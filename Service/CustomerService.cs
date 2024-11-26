using dotnet1.Dto;
using dotnet1.Entity;
using dotnet1.Repository;

namespace dotnet1.Service{
    public class CustomerService(ICustomerRepository repository) : ICustomerService
{
    private readonly ICustomerRepository _repository = repository;

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        return await _repository.AddAsync(customer);
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
        await _repository.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
    public async Task<Customer?> GetCustomerByUserIdAsync(string userId){
        return await _repository.GetCustomerByUserIdAsync(userId);

    }
    public async Task<int?> GetCustomerIdByUserIdAsync(string userId){
        return await _repository.GetCustomerIdByUserIdAsync(userId);
    }
   
    
}

}