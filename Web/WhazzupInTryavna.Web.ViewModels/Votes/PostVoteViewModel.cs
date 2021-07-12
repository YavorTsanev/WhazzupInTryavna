﻿namespace WhazzupInTryavna.Web.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;

    public class PostVoteViewModel
    {
        public int ActivityId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
