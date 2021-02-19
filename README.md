# Recruitinator
A recruitment web application made for a coding challenge.

JIRA:
    - Please send through an email to me at francisstanleysmith@hotmail.com to request access.
    - https://franksmithlaa.atlassian.net/secure/RapidBoard.jspa?rapidView=1&projectKey=REC
    
GIT repo:
    - https://github.com/FrankSmithSyd/Recruitinator
	
Installation / Use:
	- No CI/CD has been implemented for this, that's a whole level beyond what I can do in the timeframe allowed. Right now, the application It's intended as a direct executable application running from your IDE of choice. I'd recommend you just fire up your IDE, open the solution and execute the Web project, and go from there.

	
A bunch of tasks I didn't get around to doing, but would have liked:
- Solution Architecture:
	- Significant rushing was done here, and IMO it's the single most important part of developing a greenfield solution. Although I had initially intended for the application to follow a N-Layer architecture pattern, building these pieces properly takes alot of thought. In the end, I managed to tease out my project responsibilities and dependencies OK, but far from the imagined design I had originally intended. This is something I'd love to come back and do with a more senior dev's input. Despite this, we still have relatively strong separation of concern, though our coupling is a bit too string for my liking.
- Frontend:
	- Make it WAY prettier; trying to timebox to just a few hours and make a decent looking webapp is quite the rush job, so I made lots of sacrifices here.
	- Extract all view strings to a culture language lookup dictionary to allow for multiple languages and resuse of common terms.
	- Authentication. 
	- User types: I'd like to extend the application in the future with multiple user types, recruiters and job seekers could probably both use this app.
	- Callback implementation is nonexistant; this way particularly annoying with my CandidateJobMatches views. See CandidateJobMatches.cshtml for a bit more info.
- Backend:
	- Repository layer: 
		- Strictly speaking, when following the repository pattern we should have a separate repository for each primary entity we are utilizing; I didn't bother extracting out and creating separate repositories for both Jobs and Candidates, but the bones are all in place to do this.
		- Our entites are currently a little too tightly coupled to the external system. There are a few cases where I am changing behavior of our backend based on the JobAdder API's implementation (for example, with some entity names and attributes). We could solve this by adding some data mapping, but I didn't have time for this.
		- Data validation completely missing. I like to implement a validation layer sitting beside the repository which is responsible for checking data. This would be particularly important in my application since we're relying on external APIs for our data. This could catch some duplicate data cases (for example, some candidates have duplicate skill tags, which we could sanitize and elimintate) as well.
	- 
	