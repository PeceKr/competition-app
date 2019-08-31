using System;
using System.Collections.Generic;
using System.Linq;
using Competition.App.Common.ViewModels.Competition;
using Competition.App.Common.ViewModels.Teams;
using Competition.App.Domain.Entities;
using Competition.App.Domain.Repository;

namespace Competition.App.Common.ModelFactory
{
    public class ModelsFactory : IModelsFactory
    {
        private readonly IRepository _repository;

        public ModelsFactory(IRepository repository)
        {
            _repository = repository;
        }

        public Competitions CreateCompetitionEntity(CompetitionViewModel model)
        {
            var competitionEntity =  new Competitions
            {
                Active = true,
                CompetitionName = model.CompetitionName,
                DateStarted = DateTime.Now,
                Teams = _repository.GetAll<Teams>().Where(x => model.TeamIds.Contains(x.TeamId)).ToList()
            };

            _repository.Insert(competitionEntity);
            _repository.Save();

            return competitionEntity;
        }

        public Teams CreateTeamsEntityObject(TeamsViewModel viewModel)
        {
            return new Teams
            {
                TeamName = viewModel.TeamName,
                Country = viewModel.Country
            };
        }

        public TeamsViewModel CreateTeamViewModel(Teams team)
        {
            return new TeamsViewModel
            {
                TeamId = team.TeamId,
                TeamName = team.TeamName,
                Country = team.Country
            };
        }

        public Teams MapTeamObjectForEdit(Teams entity, TeamsViewModel viewModel)
        {
            entity.TeamName = viewModel.TeamName;
            entity.Country = viewModel.Country;

            return entity;
        }

        public List<CompetitionViewModel> ReturnCompetitionsViewModel(List<Competitions> competitions)
        {
            return competitions.ConvertAll(x => new CompetitionViewModel
            {
                CompetitionId = x.CompetitionId,
                CompetitionName = x.CompetitionName,
                DateStarted = x.DateStarted,
                Status = x.Active ? "Active" : "Finished"
            });
        }

        public List<TeamsViewModel> ReturnTeamsViewModelList(List<Teams> teams)
        {
            return teams.ConvertAll(x => new TeamsViewModel
            {
                Country = x.Country,
                TeamId = x.TeamId,
                TeamName = x.TeamName
            }).ToList();
        }
    }
}
