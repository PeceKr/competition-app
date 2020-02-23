using Competition.App.Common.ViewModels.Competition;
using System.Collections.Generic;

namespace Competition.App.Services.CompetitionServices
{
    public interface ICompetitionServices
    {
        void Create(CompetitionViewModel model);

        List<CompetitionViewModel> GetAll();
        void Delete(int competitionId);

        CompetitionStandingsViewModel GetStandings(int competitionId);
    }
}
