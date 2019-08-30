namespace Competition.App.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        CompetitionId = c.Int(nullable: false, identity: true),
                        CompetitionName = c.String(),
                        Active = c.Boolean(nullable: false),
                        DateStarted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(maxLength: 40),
                        Country = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        CompetitionId = c.Int(nullable: false),
                        HomeScore = c.Int(nullable: false),
                        AwayScore = c.Int(nullable: false),
                        Finished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.Teams", t => t.AwayTeamId, cascadeDelete: false)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId, cascadeDelete: false)
                .ForeignKey("dbo.Teams", t => t.HomeTeamId, cascadeDelete: false)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.CompetitionId);
            
            CreateTable(
                "dbo.TeamsCompetitions",
                c => new
                    {
                        Teams_TeamId = c.Int(nullable: false),
                        Competitions_CompetitionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teams_TeamId, t.Competitions_CompetitionId })
                .ForeignKey("dbo.Teams", t => t.Teams_TeamId, cascadeDelete: true)
                .ForeignKey("dbo.Competitions", t => t.Competitions_CompetitionId, cascadeDelete: true)
                .Index(t => t.Teams_TeamId)
                .Index(t => t.Competitions_CompetitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "HomeTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.Matches", "AwayTeamId", "dbo.Teams");
            DropForeignKey("dbo.TeamsCompetitions", "Competitions_CompetitionId", "dbo.Competitions");
            DropForeignKey("dbo.TeamsCompetitions", "Teams_TeamId", "dbo.Teams");
            DropIndex("dbo.TeamsCompetitions", new[] { "Competitions_CompetitionId" });
            DropIndex("dbo.TeamsCompetitions", new[] { "Teams_TeamId" });
            DropIndex("dbo.Matches", new[] { "CompetitionId" });
            DropIndex("dbo.Matches", new[] { "AwayTeamId" });
            DropIndex("dbo.Matches", new[] { "HomeTeamId" });
            DropTable("dbo.TeamsCompetitions");
            DropTable("dbo.Matches");
            DropTable("dbo.Teams");
            DropTable("dbo.Competitions");
        }
    }
}
