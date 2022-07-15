using System.ComponentModel.DataAnnotations;

namespace RegistryApp.DTOs
{
    public record CreateOrUpdateCustomerDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        public string City { get; set; }
        public string Tel { get; set; }
    }
}
