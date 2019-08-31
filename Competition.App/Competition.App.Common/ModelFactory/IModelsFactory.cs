using Competition.App.Common.ViewModels.Competition;
using Competition.App.Common.ViewModels.Teams;
using Competition.App.Domain.Entities;
using System.Collections.Generic;

namespace Competition.App.Common.ModelFactory
{
    public interface IModelsFactory
    {
        Teams CreateTeamsEntityObject(TeamsViewModel viewModel);

        List<TeamsViewModel> ReturnTeamsViewModelList(List<Teams> teams);

        TeamsViewModel CreateTeamViewModel(Teams team);

        Teams MapTeamObjectForEdit(Teams entity, TeamsViewModel viewModel);

        List<CompetitionViewModel> ReturnCompetitionsViewModel(List<Competitions> competitions);

        Competitions CreateCompetitionEntity(CompetitionViewModel model);
    }
}
