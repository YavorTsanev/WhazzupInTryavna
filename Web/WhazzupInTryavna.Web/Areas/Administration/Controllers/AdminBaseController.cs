using Microsoft.AspNetCore.Authorization;
using WhazzupInTryavna.Common;
using WhazzupInTryavna.Web.Controllers;

namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public abstract class AdminBaseController : BaseController
    {
    }
}
