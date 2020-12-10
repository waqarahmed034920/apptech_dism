using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyPortal.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel : IValidatableObject
    {
        [Display(Name = "Role")]
        public string Role { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> RoleList { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "Roll No")]
        public string RollNo { get; set; }
        [Display(Name = "Class")]
        public string ClassName { get; set; }
        public string Section { get; set; }
        [Display(Name = "Admission Date")]
        public DateTime? AdmissionDate { get; set; }

        [Display(Name = "Employee No")]
        public string EmployeeNo { get; set; }
        public string Specification { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!eitherAdmissionOrHireDateProvided())
                yield return new ValidationResult("Please provide either admission date or hire date", new[] { "AdmissionDate", "HireDate" });
        }

        public bool eitherAdmissionOrHireDateProvided()
        {
            var ad = AdmissionDate ?? null;
            var hd = HireDate ?? null;
            return (ad == null && hd == null) ? false : true;
        }

        public bool isValidDate(string dt)
        {
            DateTime tempDate;
            return DateTime.TryParse(dt, out tempDate);
        }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
