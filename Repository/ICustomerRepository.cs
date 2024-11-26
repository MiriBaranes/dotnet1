using dotnet1.Entity;

namespace dotnet1.Repository{
    public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer> AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
    public  Task<Customer?> GetCustomerByUserIdAsync(string userId);
    public  Task<int?> GetCustomerIdByUserIdAsync(string userId);
}

}