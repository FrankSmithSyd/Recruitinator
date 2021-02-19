# Recruitinator
A recruitment web application made for a coding challenge.

JIRA:
    - Please send through an email to me at francisstanleysmith@hotmail.com to request access.
    - https://franksmithlaa.atlassian.net/secure/RapidBoard.jspa?rapidView=1&projectKey=REC
    
GIT repo:
    - https://github.com/FrankSmithSyd/Recruitinator
	
Installation / Use:
	- No CI/CD has been implemented for this, that's a whole level beyond what I can do in the timeframe allowed. Right now, the application It's intended as a direct executable application running from your IDE of choice. I'd recommend you just fire up your IDE, open the solution and execute the Web project, and go from there.


Solution Architecture:
- CORE
	- The Core Project is the centre of our architectural design, all other projects dependencies should point toward it.
	- Designed to have few (if any) external dependencies, to allow for as much flexibility as possible.
	- Includes things like the following:
		- Entities
		- Logic
- Infastructure 
	- The Infrastructure project is responsible for mediating between our domain and data mapping layers. We could probably rename project DAL for better clarity.
	- It also contains classes with dependencies on external resources. 
	- As we are consuming the results of the JobAdder coding challenge API, this is where we shall do so.
	- JobAdder API actions ( see  https://jobadder1.docs.apiary.io/#reference )
		- http://private-76432-jobadder1.apiary-mock.com/candidates
		- http://private-76432-jobadder1.apiary-mock.com/jobs
	- This is where I'd put other data consuming code, such as EF or other external APIs, which I'm sure a more complex solution would need.
- Web
	- Web is a ASP.NET Core Web App (MVC) project, implementing a Service/Repository layer that gets its data from the Infastructure project and passes logic responsibilities through to the Core project.
	- Contains front end for the Recruitinator solution
	- Stack:
		- Razor
		- Javascript
		- Styling: Bootstrap
		
A bunch of tasks I didn't get around to doing, but would have liked:

- Solution Architecture:
	- Significant rushing was done here, and IMO it's the single most important part of developing a greenfield solution that cannot afford to be rushed. Although I had initially intended for the application to follow a N-Layer architecture pattern, building these pieces properly takes alot of thought. In the end, I managed to tease out my project responsibilities and dependencies OK, but far from the imagined design I had originally intended. This is something I'd love to come back and do with a more senior dev's input. Despite this, we still have relatively strong separation of concern, though our coupling is a bit too string for my liking.
- Frontend:
	- Make it WAY prettier; trying to timebox to just a few hours and make a decent looking webapp is quite the rush job, so I made lots of sacrifices here.
	- Extract all view strings to a culture language lookup dictionary to allow for multiple languages and resuse of common terms.
	- Authentication. 
	- User types: I'd like to extend the application in the future with multiple user types, recruiters and job seekers could probably both use this app.
	- Callback implementation is nonexistant; this way particularly annoying with my CandidateJobMatches views. See CandidateJobMatches.cshtml for a bit more info.
- Backend:
	- THIS IS A HAPPY PATH APPLICATION. No error handling or validation is currently in place!!! This is super naieve, fragile and dangerous. Given more time, this would be the no1. priority to fix
	- WEB:
		- Repository layer: 
			- Strictly speaking, when following the repository pattern we should have a separate repository for each primary entity we are utilizing; I didn't bother extracting out and creating separate repositories for both Jobs and Candidates, but the bones are all in place to do this.
			- Right now, Our entites are currently a little too tightly coupled to the external system. There are a few cases where I am changing behavior of our backend based on the JobAdder API's implementation (for example, with some entity names and attributes), which is bad. We could solve this by adding some data mapping, but I didn't have time for this.
			- Data validation completely missing. I like to implement a validation layer sitting either in Core or beside the repository. This would be particularly important in my application since we're relying on external APIs for our data. This could catch some duplicate data cases (for example, some candidates have duplicate skill tags, which we could sanitize and elimintate) as well.
- CI/CD: Any would be nice.
