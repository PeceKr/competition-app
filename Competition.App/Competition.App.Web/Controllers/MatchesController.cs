using Competition.App.Common.ViewModels.Matches;
using Competition.App.Domain.Entities;
using Competition.App.Domain.Repository;
using Competition.App.Services.MatchServices;
using Competition.App.Services.ModelFactory;
using Competition.App.Web.CustomFilters;
using System;
using System.Web.Mvc;


namespace Competition.App.Web.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IRepository _repository;
        private readonly IModelsFactory _modelsFactory;
        private readonly IMatchServices _matchServices;

        public MatchesController(IRepository repository, IModelsFactory modelsFactory , IMatchServices matchServices)
        {
            _repository = repository;
            _modelsFactory = modelsFactory;
            _matchServices = matchServices;

        }

        // GET: Matches
        public ActionResult Index(int competitionId)
        {
            var matches = _matchServices.GetAllMatches();
            ViewBag.CompatitionId = competitionId;

            return View(matches);
        }

        [HttpGet]
        public ActionResult CreateMatch(int competitionId)
        {
            var matchModel = new MatchesViewModel { CompetitionId = competitionId };
            return View(matchModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateMatch(MatchesViewModel model)
        {
            try
            {
                var teamModel = _modelsFactory.CreateMatchEntity(model);

                _repository.Insert(teamModel);
                _repository.Save();

                return RedirectToAction("Index", new { competitionId = model.CompetitionId });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AjaxValidateAntiForgeryToken]
        public JsonResult DeleteMatch(int matchId)
        {
            try
            {
                var match = _repository.GetById<Matches>(matchId);

                if (match != null)
                {
                    _repository.Delete(match);
                    _repository.Save();

                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AjaxValidateAntiForgeryToken]
        public JsonResult SaveResult (int homeScore, int awayScore, int matchId)
        {
            try
            {
                 _matchServices.SaveResult(homeScore, awayScore, matchId);


                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
         
        }


    }
}