using System;
using System.Collections.Generic;
using Competition.App.Common.ViewModels.Matches;
using Competition.App.Domain.Repository.MatchRepository;
using Competition.App.Services.ModelFactory;

namespace Competition.App.Services.MatchServices
{
    public class MatchesServices : IMatchServices
    {
        private readonly IMatchRepository _repository;
        private readonly IModelsFactory _modelsFactory;
        public MatchesServices(IMatchRepository repository , IModelsFactory modelsFactory)
        {
            _repository = repository;
            _modelsFactory = modelsFactory;
        }
        public List<MatchesViewModel> GetAllMatches()
        {
            try
            {
                var matches = _repository.GetAllMatches();

                return matches;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
