# Software Dependencies

This app uses .NET Core 2.2 and Angular 6.  Please ensure these are installed before running.

- .NET Core 2.2 SDK Download - https://dotnet.microsoft.com/download/dotnet-core/2.2
- Angular depends on Node and NPM - https://nodejs.org/en/
- Angular Command Line Interface - https://www.npmjs.com/package/@angular/cli
  - Ensure that the prerequisites for this are met before installing - https://www.npmjs.com/package/@angular/cli#prerequisites

The 'npm' and 'ng' commands should be available to Visual Studio after these installations are complete.  A restart may be required.

# Database Creation and Migration

The app expects to connect to a Sql Server database using the PeopleSearchDatabase connection string.
This connection string can be found in the appsettings.json file inside the web project.
Please change this value if necessary in order to provide a database to the app.

To create the database, open the Package Manager Console and change the default project to PeopleSearch.Persistence.
Run the command 'Update-Database'.  After running this command the database should be created with migrations applied.

# Testing

## Unit Tests

In order to run the tests for the Angular client app,
run the command 'ng test' from inside the ClientApp directory of the Web project.
This will start up the Karma test runner.
To run the Api tests please use the Visual Studio Test Explorer.

## Simulation of Slow Search

In order to simulate a slow search I used Google Chrome's developer tools to throttle the connection speed.
The throttle settings are under the Network tab on the top right where it says "Offline" and "No throttling".
I reached out to Trent Wignall to confirm that this was OK for the assessment.
I used the "Slow 3G" and "Offline" presets, but custom speeds and latency settings are also available.
I first let the page load before throttling the connection, this way only the search operation is slowed.

# Technologies Used

## Front End

- Angular 6
- Node.js
- Karma test runner
- Jasmine testing framework
- Rxjs reactive programming library

## Back End

- .NET Core 2.2
- Entity Framework Core
- Automapper
- Autofixture
- Fluent Assertions
- NUnit testing framework

# Possible improvements

## Create New Person

Creates a new person that will show up in searches.
This would involve uploading a profile picture, which could also involve a client-side image editing tool if we wanted to get fancy.
This image editor could enforce image size and dimensions before uploading to the back end (which would also check these).
We could also store these images in Azure or AWS instead of our own server.

## Interests as Tags

Person interests could be divided up into comma separated tags and stored in their own Interests table.
This would allow us to suggest interests to the user and connect the same interests between people added to the system.
This would involve a many to many relationship.
I was trying to implement this, but soon found out that Entity Framework Core does not support many to many relationships.
Because of this the junction table would have to be maintained manually and queries would be more difficult to write.
I decided to just use the 'text' data type for interests and focus on finishing the rest of the assessment.

## Client-Side Paging

Instead of a regular table we could use a paged table that puts, say, 5 people at a time on a page in the results.
We probably wouldn't need to page the API endpoint itself since it's a relatively small amount of data, at least right now.

# Miscellaneous Notes

In order to access the API outside of the web app when running locally, make sure whatever tool you are using does not reject self-signed SSL certificates.
