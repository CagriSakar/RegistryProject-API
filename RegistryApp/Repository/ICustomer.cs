using RegistryApp.Models;

namespace RegistryApp.Repository
{
    public interface ICustomer
    {
        public IEnumerable<Customer> GetCustomers();
        public Customer GetCustomer(Guid id);
        public void CreateCustomer(Customer customer);
        public void UpdateCustomer(Guid id, Customer customer);
        public void DeleteCustomer(Guid id);

    }
}
