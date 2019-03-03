# Social Point Ranking Test

**The current supported Visual Studio version for Social Point Ranking Test is Visual Studio 2017 15.9** or later version.

**Steps to build the application:**

    01.- Open the solution file (SocialPointTest.Ranking.sln) with MS Visual Studio 2017.
    02.- On the menu bar, choose Build -> Build or ReBuild Solution (The output window displays the results of the build)

**Steps to run the web application:**

    01.- In solution explorer, select the project SocialPointTest.Ranking.WebApi.
    02.- On the project menu, choose Set as StartUp Project.
    03.- Select the project SocialPointTest.Ranking.WebApi in Solution Explorer, press right-click and choose Properties.
    04.- Select Web tab.
    05.- In the Properties pane, under Servers, select IIS Express from the dropdown.
    06.- Write the project url in Project Url field and select Create Virtual Directory. By default: http://localhost:61817/
    07.- Use File -> Save Selected Items
    08.- To start application, select IIS Express in the toolbar and press F5.

**Ranking by default:**

    UserName    UserId    	Score
    --------    --------    -----
    Player1		1			250
    Player2 	2			120
    Player3		3			360
    Player4		4			210
    Player5		5			564
    Player6		6			99
    Player7		7			670
    Player8		8			820
    Player9		9			950
    Player10	10			400
	
**User API call examples:**

Get top 7 ranking (GET): http://localhost:61817/ranking/get-ranking/7

Get relative ranking of 3 users around position 2 (GET): http://localhost:61817/ranking/get-relative-ranking/3/2

Update absolute ranking for userid 5 (PUT): http://localhost:61817/ranking/update-absolute-score -> User data in body. Example: 
{
	"UserId":5,
	"TotalScore":1000
}

Update relative ranking for userid 5 (PUT): http://localhost:61817/ranking/update-relative-score -> User data in body. Examples:
{
	"UserId":5,
	"Score":500
}
or
{
	"UserId":5,
	"Score":-500
}