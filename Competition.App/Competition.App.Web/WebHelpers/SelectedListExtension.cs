using Competition.App.Domain;
using Competition.App.Domain.Entities;
using Competition.App.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Competition.App.Web.WebHelpers
{
    public static class SelectedListExtension
    {
        private static readonly IRepository _objRepository = new Repository(new ApplicationDbContext());
        public static IEnumerable<SelectListItem> GetAllTeams()
        {

            var teams = _objRepository.GetAll<Teams>();

            List<SelectListItem> lstTeams = teams.Select(s => new SelectListItem()
            {
                Text = s.TeamName.ToString(),
                Value = s.TeamId.ToString(),
            }).ToList();

            return lstTeams;
        }
    }
}