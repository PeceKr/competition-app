using Competition.App.Common;
using Competition.App.Common.ModelFactory;
using Competition.App.Common.ViewModels.Teams;
using Competition.App.Domain.Entities;
using Competition.App.Domain.Repository;
using System;
using System.Collections.Generic;
namespace Competition.App.Services.TeamsServices
{
    public class TeamsServices : ITeamsServices
    {
        private readonly IRepository _repository;
        private readonly IModelsFactory _modelsFactory;
        public TeamsServices(IRepository repository, IModelsFactory modelsFactory)
        {
            _repository = repository;
            _modelsFactory = modelsFactory;
        }

        public void CreateTeam(TeamsViewModel teamModel)
        {
            try
            {
                var team = _modelsFactory.CreateTeamsEntityObject(teamModel);

                _repository.Insert(team);

                _repository.Save();
            }
            catch
            {

                throw;
            }
        }

        public void Delete(int teamId)
        {
            try
            {

                var team = _repository.GetById<Teams>(teamId);

                if (team == null) throw new Exception("Team with this id not found");

                _repository.Delete(team);

                _repository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditTeam(TeamsViewModel teamsViewModel)
        {
            try
            {
                var team = _repository.GetById<Teams>(teamsViewModel.TeamId);

                if (team == null) throw new Exception("Not found");

                var editedTeam = _modelsFactory.MapTeamObjectForEdit(team, teamsViewModel);

                _repository.Update(editedTeam);
                _repository.Save();
            }
            catch
            {
                throw;
            }
        }

        public List<TeamsViewModel> GetAllTeams()
        {
            try
            {
                var teams = _modelsFactory.ReturnTeamsViewModelList(_repository.GetAll<Teams>());

                return teams;
            }
            catch
            {
                throw;
            }
        }

        public TeamsViewModel GetById(int teamId)
        {
            try
            {
                var team = _modelsFactory.
                    CreateTeamViewModel(_repository.SingleOrDefault<Teams>(x => x.TeamId == teamId));

                return team;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
