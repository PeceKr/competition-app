using Competition.App.Common;
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

        public TeamsServices(IRepository repository)
        {
            _repository = repository;
        }

        public void CreateTeam(TeamsViewModel teamModel)
        {
            try
            {
                var team = ModelFactory.CreateTeamsEntityObject(teamModel);

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

                var editedTeam = ModelFactory.MapTeamObjectForEdit(team, teamsViewModel);

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
                var teams = ModelFactory.ReturnTeamsViewModelList(_repository.GetAll<Teams>());

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
                var team = ModelFactory.
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
