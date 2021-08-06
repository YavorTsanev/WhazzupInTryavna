namespace WhazzupInTryavna.Web.ViewModels.Contact
{
    using System.ComponentModel.DataAnnotations;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class ContactFormModel
    {
        [Required]
        [MinLength(ContactNameMinLength)]
        [MaxLength(ContactNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(ContactEmailRegEx, ErrorMessage = EmailNotValid)]
        public string Email { get; set; }

        [Required]
        [MinLength(ContactSubjectMinLength)]
        [MaxLength(ContactSubjectMaxLength)]
        public string Subject { get; set; }

        [Required]
        [MinLength(ContactMessageMinLength)]
        [MaxLength(ContactMessageMaxLength)]
        public string Message { get; set; }
    }
}
