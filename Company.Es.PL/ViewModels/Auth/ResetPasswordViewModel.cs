using System.ComponentModel.DataAnnotations;

namespace Company.Es.PL.ViewModels.Auth
{
	public class ResetPasswordViewModel
	{
		[Required(ErrorMessage = "Password is Required!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirmed Password is Required!")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Confirmed password must match with Password")]
		public string ConfirmPassword { get; set; }
	}
}
