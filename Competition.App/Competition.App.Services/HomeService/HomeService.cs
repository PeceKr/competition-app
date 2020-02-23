using System;
using Competition.App.Common.ViewModels.Home;
using Competition.App.Domain.Repository.CompetitionRepository;
using Competition.App.Domain.Repository.MatchRepository;
using Competition.App.Domain.Repository.TeamsRepository;

namespace Competition.App.Services.HomeService
{
    public class HomeService : IHomeService
    {

        private readonly IMatchRepository _repository;
        private readonly ICompetitionRepository _competitionRepository;
        private readonly ITeamsRepository _teamsRepository;
        public HomeService(IMatchRepository repository, ICompetitionRepository competitionRepository, ITeamsRepository teamsRepository)
        {
            _repository = repository;
            _competitionRepository = competitionRepository;
            _teamsRepository = teamsRepository;
        }
        public DashboardResultsViewModel getDashBoardStats()
        {
            return new DashboardResultsViewModel
            {
                ActiveCompettions = _competitionRepository.GetCompetitionsCount(),
                ActiveTeams = _teamsRepository.GetActiveTeams(),
                MatchesInProgress = _repository.GetActiveMatches(),
                MatchResults = _repository.GetFinishedMatches()
            };
        }
    }
}
