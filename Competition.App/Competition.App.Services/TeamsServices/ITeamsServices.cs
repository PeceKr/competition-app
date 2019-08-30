using Competition.App.Common.ViewModels.Teams;
using System.Collections.Generic;

namespace Competition.App.Services.TeamsServices
{
    public interface ITeamsServices
    {
        void CreateTeam(TeamsViewModel teamModel);

        void EditTeam(TeamsViewModel teamsViewModel);

        List<TeamsViewModel> GetAllTeams();

        TeamsViewModel GetById(int teamId);

        void Delete(int teamId);
    }
}
