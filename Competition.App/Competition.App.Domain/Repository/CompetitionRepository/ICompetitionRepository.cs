using Competition.App.Common.ViewModels.Competition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.App.Domain.Repository.CompetitionRepository
{
    public interface ICompetitionRepository
    {
        int GetCompetitionsCount();

        CompetitionStandingsViewModel GetCompetitionStandings(int competitionId);
    }
}
