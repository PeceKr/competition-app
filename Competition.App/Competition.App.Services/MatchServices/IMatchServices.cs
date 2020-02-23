using Competition.App.Common.ViewModels.Matches;
using Competition.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.App.Services.MatchServices
{
    public interface IMatchServices
    {
        List<MatchesViewModel> GetAllMatches();

        Matches GetMatchById(int matchId);

        void SaveResult(int homeScore, int awayScore, int matchId);
    }
}
