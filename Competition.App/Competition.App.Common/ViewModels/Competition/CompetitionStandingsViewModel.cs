using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.App.Common.ViewModels.Competition
{
    public class CompetitionStandingsViewModel
    {

        public string CompetitionName { get; set; }

        public List<StandingsItem> Items { get; set; }
    }

    public class StandingsItem
    {
        public int Points { get; set; }

        public string TeamName { get; set; }
    }
}
