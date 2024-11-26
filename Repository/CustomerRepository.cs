using dotnet1.Data;
using dotnet1.Entity;
using Microsoft.EntityFrameworkCore;

namespace dotnet1.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        
        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

   
        public async Task<Customer> AddAsync(Customer customer)
        {
            var toSave =await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return toSave.Entity;
        }

        
        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Customer?> GetCustomerByUserIdAsync(string userId)
        {
            return await _context.Customers
                .Include(c => c.Orders) 
                .ThenInclude(o => o.OrderDetails) 
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<int?> GetCustomerIdByUserIdAsync(string userId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.UserId == userId);
            return customer?.CustomerId; // Use CustomerId instead of Id
        }
    }
}
