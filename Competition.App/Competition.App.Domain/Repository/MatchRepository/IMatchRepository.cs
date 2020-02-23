using Competition.App.Common.ViewModels.Matches;
using System.Collections.Generic;

namespace Competition.App.Domain.Repository.MatchRepository
{
    public interface IMatchRepository
    {
        List<MatchesViewModel> GetAllMatches();

        int GetActiveMatches();

        int GetFinishedMatches();
    }
}
