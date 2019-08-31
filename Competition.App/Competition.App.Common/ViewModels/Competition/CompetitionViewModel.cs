using Competition.App.Common.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Competition.App.Common.ViewModels.Competition
{
    public class CompetitionViewModel
    {
        public int CompetitionId { get; set; }

        [Required]
        [Display(Name ="Competition Name")]
        public string CompetitionName { get; set; }

        public DateTime DateStarted { get; set; }

        public string Status { get; set; }

        public List<TeamsViewModel> Teams { get; set; }

        public int[] TeamIds { get; set; }
    }
}
