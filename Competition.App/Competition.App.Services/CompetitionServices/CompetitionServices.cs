using System.Collections.Generic;
using Competition.App.Common.ViewModels.Competition;
using Competition.App.Domain.Entities;
using Competition.App.Domain.Repository;
using Competition.App.Services.ModelFactory;

namespace Competition.App.Services.CompetitionServices
{
    public class CompetitionServices : ICompetitionServices
    {
        private readonly IRepository _repository;
        private readonly IModelsFactory _modelFactory;

        public CompetitionServices(IRepository repository, IModelsFactory modelsFactory)
        {
            _repository = repository;
            _modelFactory = modelsFactory;
        }

        public void Create(CompetitionViewModel model)
        {
            try
            {
                var competitionEntity = _modelFactory.CreateCompetitionEntity(model);

                
                _repository.Save();
            }
            catch 
            {
                throw;
            }
        }

        public void Delete(int competitionId)
        {
            try
            {
                 _repository.Delete<Competitions>(competitionId);

                _repository.Save();
            }
            catch
            {

                throw;
            }
        }

        public List<CompetitionViewModel> GetAll()
        {
            try
            {
                return _modelFactory.ReturnCompetitionsViewModel(_repository.GetAll<Competitions>());
                
            }
            catch 
            {
                throw;
            }
        }
    }
}
