using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.App.Domain.Repository.TeamsRepository
{
    public interface ITeamsRepository
    {
        int GetActiveTeams();
    }
}
