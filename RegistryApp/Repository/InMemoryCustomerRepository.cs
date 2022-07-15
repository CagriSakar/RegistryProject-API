using RegistryApp.Models;

namespace RegistryApp.Repository
{
    public class InMemoryCustomerRepository : ICustomer
    {
        private List<Customer> _Customers;
        public InMemoryCustomerRepository()
        {
            _Customers = new() { new Customer { Id = Guid.NewGuid(), Name = "Deneme İsim", Surname = "Deneme Soyisim", City = "Deneme Şehir", Email = "deneme@mail.com", Tel = "+90555deneme " } };
        }
        public void CreateCustomer(Customer customer)
        {
            _Customers.Add(customer);
        }

        public void DeleteCustomer(Guid id)
        {
            var customerIndex = _Customers.FindIndex(x => x.Id == id);
            if (customerIndex > -1)
                _Customers.RemoveAt(customerIndex);
        }

        public Customer GetCustomer(Guid id)
        {
            var customer = _Customers.Where(x => x.Id == id).SingleOrDefault();
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _Customers;
        }

        public void UpdateCustomer(Guid id, Customer customer)
        {
            var customerIndex = _Customers.FindIndex(x => x.Id == id);
            if (customerIndex>-1)
                _Customers[customerIndex] = customer;
        }
    }
}
