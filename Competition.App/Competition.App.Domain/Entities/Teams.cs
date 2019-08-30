using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Competition.App.Domain.Entities
{
    public class Teams
    {
        [Key]
        public int TeamId { get; set; }

        [StringLength(40)]
        public string TeamName { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        public virtual ICollection<Competitions> Competitions { get; set; }
    }
}
