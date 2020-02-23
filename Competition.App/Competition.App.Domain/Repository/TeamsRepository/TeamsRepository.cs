using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Competition.App.Domain.Repository.TeamsRepository
{
    public class TeamsRepository : ITeamsRepository
    {
        public int GetActiveTeams()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["CompetitonsConnString"].ConnectionString))
            {
                var matches = db.ExecuteScalar<int>("Select COUNT(TeamId) from Teams");

                return matches;
            }
        }
    }
}
