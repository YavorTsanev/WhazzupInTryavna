using System;
using System.Collections.Generic;
using System.Text;
using WhazzupInTryavna.Data.Common.Models;

namespace WhazzupInTryavna.Data.Models.Activities
{
    public class UserActivity : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
