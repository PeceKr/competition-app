using System;
using System.Collections.Generic;
using Competition.App.Common.ViewModels.Matches;
using Competition.App.Domain.Entities;
using Competition.App.Domain.Repository;
using Competition.App.Domain.Repository.MatchRepository;
using Competition.App.Services.ModelFactory;

namespace Competition.App.Services.MatchServices
{
    public class MatchesServices : IMatchServices
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IModelsFactory _modelsFactory;
        private readonly IRepository _repository;

        public MatchesServices(IMatchRepository _atchRepository, IModelsFactory modelsFactory , IRepository repository)
        {
            _matchRepository = _atchRepository;
            _modelsFactory = modelsFactory;
            _repository = repository;
        }
        public List<MatchesViewModel> GetAllMatches()
        {
            try
            {
                var matches = _matchRepository.GetAllMatches();

                return matches;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Matches GetMatchById(int matchId)
        {
            try
            {
                return _repository.GetById<Matches>(matchId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SaveResult(int homeScore, int awayScore, int matchId)
        {
            try
            {
                var match = _repository.GetById<Matches>(matchId);

                match.HomeScore = homeScore;
                match.AwayScore = awayScore;

                _repository.Update(match);
                _repository.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
