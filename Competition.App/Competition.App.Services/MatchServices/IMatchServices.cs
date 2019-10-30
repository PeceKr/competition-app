using Competition.App.Common.ViewModels.Matches;
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
    }
}
