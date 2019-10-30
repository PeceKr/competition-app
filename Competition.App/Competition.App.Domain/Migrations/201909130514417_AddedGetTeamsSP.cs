namespace Competition.App.Domain.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedGetTeamsSP : DbMigration
    {
        public override void Up()
        {
            string body = @"SET NOCOUNT ON;
                          SELECT m.MatchId,m.StartTime,m.CompetitionId,ht.TeamName as HomeTeamName,awt.TeamName as AwayTeamName from Matches m 
    	                    inner join Teams ht on m.HomeTeamId = ht.TeamId 
    	                    inner join Teams awt on m.AwayTeamId = awt.TeamId";

            CreateStoredProcedure("spGetFixtures", body);
        }

        public override void Down()
        {
            DropStoredProcedure("spGetFixtures");
        }
    }
}
