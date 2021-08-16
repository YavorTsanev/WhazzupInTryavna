namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Services.Messaging;
    using WhazzupInTryavna.Web.ViewModels.Contact;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class ContactController : BaseAuthorizeController
    {
        private readonly IEmailSender emailSender;

        public ContactController(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.emailSender.SendEmailAsync(AdminConst.Email, model.Name, AppConst.EmailForContact, model.Subject, model.Message + " " + model.Email);

            this.TempData["SuccessSentEmail"] = "Message send successfully";

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
