using Microsoft.AspNetCore.Mvc;
using RegistryApp.DTOs;
using RegistryApp.Models;
using RegistryApp.Repository;

namespace RegistryApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _CustomerRepository;
        public CustomersController(ICustomer customerRepository)
        {
            _CustomerRepository = customerRepository;
        }
        [HttpGet("getall")]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            return _CustomerRepository.GetCustomers().Select(x => new CustomerDto { Id = x.Id, Name = x.Name, Surname = x.Surname, City = x.City, Email = x.Email, Tel = x.Tel }).ToList();
        }
        [HttpGet("get")]
        public ActionResult<CustomerDto> GetCustomer(Guid id)
        {
            var customer = _CustomerRepository.GetCustomer(id);

            if (customer == null)
                return NotFound();

            var customerDto = new CustomerDto { Id = customer.Id, Name = customer.Name, Surname = customer.Surname, City = customer.City, Email = customer.Email, Tel = customer.Tel };
            return customerDto;
        }
        [HttpPost]
        public ActionResult CreateCustomer(CreateOrUpdateCustomerDto customer)
        {
            var mycustomer = new Customer();
            mycustomer.Id = Guid.NewGuid();
            mycustomer.Name = customer.Name;
            mycustomer.Surname = customer.Surname;
            mycustomer.City = customer.City;
            mycustomer.Email = customer.Email;
            mycustomer.Tel = customer.Tel;

            _CustomerRepository.CreateCustomer(mycustomer);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateCustomer(Guid id, CreateOrUpdateCustomerDto customer)
        {
            var mycustomer = _CustomerRepository.GetCustomer(id);

            if (customer == null)
                return NotFound();

            mycustomer.Name = customer.Name;
            mycustomer.Surname = customer.Surname;
            mycustomer.City = customer.City;
            mycustomer.Email = customer.Email;
            mycustomer.Tel = customer.Tel;

            _CustomerRepository.UpdateCustomer(id, mycustomer);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteCustomer(Guid id)
        {
            var customer = _CustomerRepository.GetCustomer(id);
            if (customer == null)
                return NotFound();
            _CustomerRepository.DeleteCustomer(id);
            return Ok();
        }

    }
}
