using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Competition.App.Domain.Entities
{
    public class Matches
    {
        [Key]
        public int MatchId { get; set; }

        public DateTime StartTime { get; set; }

        public int HomeTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public Teams HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public Teams AwayTeam { get; set; }

        public int CompetitionId { get; set; }

        [ForeignKey("CompetitionId")]
        public Competitions Competiton { get; set; }

        public int HomeScore { get; set; }

        public int AwayScore { get; set; }

        public bool Finished { get; set; }
    }
}
