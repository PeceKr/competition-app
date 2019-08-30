using Competition.App.Common.ViewModels.Teams;
using Competition.App.Services.TeamsServices;
using System;
using System.Web.Mvc;

namespace Competition.App.Web.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamsServices _teamServices;

        public TeamsController(ITeamsServices teamsServices)
        {
            _teamServices = teamsServices;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var teams = _teamServices.GetAllTeams();
            return View(teams);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _teamServices.CreateTeam(model);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception)
            {
                // Handle and log the exception
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit (int teamId)
        {
            try
            {
                var team = _teamServices.GetById(teamId);

                return View(team);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit (TeamsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _teamServices.EditTeam(model);

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult DeleteTeam (int teamId)
        {
            try
            {
                _teamServices.Delete(teamId);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                // Handle and log exception
                throw;
            }
        }

    }
}