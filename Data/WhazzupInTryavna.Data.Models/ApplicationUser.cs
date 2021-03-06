// ReSharper disable VirtualMemberCallInConstructor

namespace WhazzupInTryavna.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using WhazzupInTryavna.Data.Common.Models;
    using WhazzupInTryavna.Data.Models.Activities;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();

        public virtual ICollection<UserActivity> UserActivities { get; set; } = new HashSet<UserActivity>();

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
