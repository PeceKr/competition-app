GO

CREATE PROCEDURE [dbo].[spGetStandings]
@competitonId int
AS
BEGIN
    SET NOCOUNT ON;
   
   Select CompetitionName from Competitions where CompetitionId = @competitonId

   SELECT TeamName, SUM(points) AS Points
FROM (
  SELECT TeamName, 
         CASE 
            WHEN HomeScore > AwayScore THEN 3
            WHEN HomeScore = AwayScore THEN 1
            ELSE 0
         END AS points
  FROM Matches m Inner join Teams t on m.HomeTeamId = t.TeamId

  UNION ALL

  SELECT TeamName , 
         CASE 
            WHEN AwayScore > HomeScore THEN 3
            WHEN AwayScore = HomeScore THEN 1
            ELSE 0
         END AS points
   FROM Matches m Inner join Teams t on m.AwayTeamId = t.TeamId
   where m.CompetitionId = @competitonId
) AS t
GROUP BY TeamName
ORDER BY Points DESC


END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGetFixtures]
AS
BEGIN
    SET NOCOUNT ON;
    SELECT CONCAT(m.HomeScore , ' : ' , m.AwayScore) as Result ,  m.MatchId,m.StartTime,m.CompetitionId,ht.TeamName as HomeTeamName,awt.TeamName as AwayTeamName from Matches m 
    	                    inner join Teams ht on m.HomeTeamId = ht.TeamId 
    	                    inner join Teams awt on m.AwayTeamId = awt.TeamId
END


