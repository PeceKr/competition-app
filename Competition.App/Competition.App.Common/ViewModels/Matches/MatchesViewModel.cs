using System;
using System.ComponentModel.DataAnnotations;

namespace Competition.App.Common.ViewModels.Matches
{
    public class MatchesViewModel
    {
        public int MatchId { get; set; }

        [Required]
        public int HomeId { get; set; }

        [Required]
        public int AwayId { get; set; }

        public DateTime StartTime { get; set; }

        [Display(Name ="Home team")]
        public string HomeTeamName { get; set; }

        [Display(Name = "Away team")]
        public string AwayTeamName { get; set; }

        public int CompetitionId { get; set; }

        public string Result { get; set; }

        public bool Finished { get; set; }
    }
}
