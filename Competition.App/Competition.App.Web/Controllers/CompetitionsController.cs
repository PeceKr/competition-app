using Competition.App.Common.ViewModels.Competition;
using Competition.App.Services.CompetitionServices;
using Competition.App.Services.TeamsServices;
using System.Web.Mvc;

namespace Competition.App.Web.Controllers
{
    public class CompetitionsController : Controller
    {
        private readonly ICompetitionServices _competitionService;
        private readonly ITeamsServices _teamsService;


        public CompetitionsController(ICompetitionServices competitionService, ITeamsServices teamsServices)
        {
            _competitionService = competitionService;
            _teamsService = teamsServices;
        }

        [HttpGet]
        // GET: Competitions
        public ActionResult Index()
        {
            var competitons = _competitionService.GetAll();

            return View(competitons);
        }

        [HttpGet]
       public ActionResult Create ()
        {
            var teams = _teamsService.GetAllTeams();

            var model = new CompetitionViewModel();
            model.Teams = teams;

            return View(model);
        }

        [HttpPost]
        public JsonResult Create(CompetitionViewModel model)
        {
            try
            {
                _competitionService.Create(model);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                
            }
            catch (System.Exception ex)
            {
                // Handle and log the error 
                throw;
            }
        }

        [HttpPost]
        public JsonResult Delete(int competitionId)
        {
            try
            {
                _competitionService.Delete(competitionId);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            }
            catch (System.Exception ex)
            {
                // Handle and log the error 
                throw;
            }
        }

        [HttpGet]        
        public ActionResult Standings (int competitionId)
        {
            try
            {
                var standings = _competitionService.GetStandings(competitionId);

                return View(standings);
            }
            catch (System.Exception)
            {

                // Handle and log the error 
                throw;
            }
        }
    }
}