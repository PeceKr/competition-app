using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Competition.App.Domain.Entities
{
    public class Competitions
    {
        [Key]
        public int CompetitionId { get; set; }

        public string CompetitionName { get; set; }

        public bool Active { get; set; }

        public DateTime DateStarted { get; set; }

        public virtual ICollection<Teams> Teams { get; set; }

    }
}
