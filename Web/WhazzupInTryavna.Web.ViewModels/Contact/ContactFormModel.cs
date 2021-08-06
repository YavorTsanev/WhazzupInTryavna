namespace WhazzupInTryavna.Web.ViewModels.Contact
{
    using System.ComponentModel.DataAnnotations;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class ContactFormModel
    {
        [Required]
        [MinLength(ContactConst.NameMinLength)]
        [MaxLength(ContactConst.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(ContactConst.EmailRegEx, ErrorMessage = ErrorMessageConst.EmailNotValid)]
        public string Email { get; set; }

        [Required]
        [MinLength(ContactConst.SubjectMinLength)]
        [MaxLength(ContactConst.SubjectMaxLength)]
        public string Subject { get; set; }

        [Required]
        [MinLength(ContactConst.MessageMinLength)]
        [MaxLength(ContactConst.MessageMaxLength)]
        public string Message { get; set; }
    }
}
