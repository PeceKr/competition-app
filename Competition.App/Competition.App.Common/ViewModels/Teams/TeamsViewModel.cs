using System.ComponentModel.DataAnnotations;

namespace Competition.App.Common.ViewModels.Teams
{
    public class TeamsViewModel
    {
        public int TeamId { get; set; }

        [Display(Name ="Team Name")]
        [Required]
        [StringLength(40)]
        public string TeamName { get; set; }

        [Display(Name = "Country")]
        [Required]
        [StringLength(40)]
        public string Country { get; set; }
    }
}