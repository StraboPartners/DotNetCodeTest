# Strabo .NET Code Test

Welcome!

This repository contains a simple sample app, in the style of the real products you'll be working on.

It is built using:
- ASP.NET core
- Blazor
  - MudBlazor UI component library
- Entity Framework Core
  - Code first
  - PostgreSQL database

## Setup:
- .NET 7 SDK installed
- Editor of your choice
- Local PostgreSQL install with a database/user created for the app to use
  - By default the app will use the following setup, but this can be changed if desired
    - Database: `strabocodetest`
    - User: `strabo`
    - Password: `strabo`

When you start the app, it will connect to your local database, apply migrations to create the correct schema if not 
already present, and seed the database with some sample data.

## Test: 

Please review the open issues in the repository, and choose at least two to resolve. You can do more if you like.

Once the issue is resolved, open a pull request (one PR per issue).

Feel free to apply any refactorings or other changes you think would be helpful or good for the codebase, 
including any additional bugs you found.

Once you are done, let us know, and we'll schedule time to have you do a quick demo of the changes you made, and review the PR together.