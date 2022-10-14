# Bitcoin Price Fetcher

## How To Run

Get the latest changes from master branch

Update the database by running the migrations against the API project via the command:

```sh
Update-Database
```

Set multiple startup projects by right-clicking on the solution and place both the API and UI projects to start 

## Improvements to be made
- The whole UI project was not refactored properly
- Make the clicking of the Submit button asynchronous and display propper messaging
- Introduce a generic repository in the API and make use of the unit of work pattern
- Add pagination in retrieving requests
- Add even a minimal security like a static token for requests between the projects
- Add more validatons
