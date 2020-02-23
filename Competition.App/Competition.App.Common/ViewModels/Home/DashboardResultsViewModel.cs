using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.App.Common.ViewModels.Home
{
    public class DashboardResultsViewModel
    {
        public int ActiveCompettions { get; set; }

        public int ActiveTeams { get; set; }

        public int MatchResults { get; set; }

        public int MatchesInProgress { get; set; }
    }
}
