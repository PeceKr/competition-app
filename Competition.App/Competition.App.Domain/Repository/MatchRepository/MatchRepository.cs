using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Competition.App.Common.ViewModels.Matches;
using Dapper;

namespace Competition.App.Domain.Repository.MatchRepository
{
    public class MatchRepository : IMatchRepository
    {
        public List<MatchesViewModel> GetAllMatches()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["CompetitonsConnString"].ConnectionString))
            {
                var matches = db.Query<MatchesViewModel>("spGetFixtures", commandType: CommandType.StoredProcedure).ToList();

                return matches;
            }
        }
    }
}
