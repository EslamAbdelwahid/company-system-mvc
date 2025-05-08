using Company.Es.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Company.Es.PL.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }
        [Range(22, 50, ErrorMessage = "The Age must be in Range [22, 50]")]
        public int? Age { get; set; }
        [RegularExpression(@"[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}",
            ErrorMessage = "Address must be like 124-Street-City-Country")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary is Required!")]
        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }


        public bool IsActive { get; set; }
        public DateTime HiringDate { get; set; }

        public Department? WorkFor { get; set; }
        public int? WorkForId { get; set; }
        public string? ImageName {  get; set; }
        public IFormFile? Image {  get; set; }
    }
}
