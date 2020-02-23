using Competition.App.Common.ViewModels.Competition;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.App.Domain.Repository.CompetitionRepository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        public int GetCompetitionsCount()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["CompetitonsConnString"].ConnectionString))
            {
                var competitions = db.ExecuteScalar<int>("Select COUNT(CompetitionId) from Competitions");

                return competitions;
            }
        }

        public CompetitionStandingsViewModel GetCompetitionStandings(int competitionId)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["CompetitonsConnString"].ConnectionString))
            {               

                DynamicParameters dp = new DynamicParameters();

                dp.Add("@competitonId", competitionId);
                var result = db.QueryMultiple("spGetStandings", dp, commandType: CommandType.StoredProcedure);


                var competitionName = result.Read<string>();
                var Items = result.Read<StandingsItem>().ToList();


                return new CompetitionStandingsViewModel
                {
                    CompetitionName = competitionName.First(),
                    Items = Items
                };              

                
            }
        }
    }
}
