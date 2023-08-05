# About

Provides the basic operations for working with SqlLite database using EF Core.

I dumped all code into this project while there should be class projects for separating functionality e.g. class project for data operations, class project for ordering as per this [repository](https://github.com/karenpayneoregon/ef-core-order-by) in regards to dynamic `order by`.

Code once separated into class projects can be reused.


For novice developers console projects are great for learning as there is no complex user interface as in web or desktop projects hence why this was done in a console project.

Personally I will write code in a console project than turn around and rip it into class projects with the help of ReSharper which in the current code base might take ten minutes or less.

## Why?

Read a forum post that the OP had pretty much everything wrong were using EF Core in tangent with EF Power Tools would solve their issues. Note, Dapper is great but feel it would still baffle the OP.

This lead to posting on Twitter.

## Perspectives

Say ten developers review the provided code, at least three will criticize one or more things presented and they have that right but here is the deal, I write a lot of demo code and expect this from some so deal with and move on. Perspective is in the mindset of each developer.


## Database table

```sql
CREATE TABLE Person (
    Id        INTEGER     PRIMARY KEY AUTOINCREMENT,
    FirstName TEXT (50)   NOT NULL,
    LastName  TEXT (50)   NOT NULL,
    Pin       INTEGER (5) 
);
```

## Database connection

See appsettings.json

## Methods provided

Some can be improved, have at it.


## Logging

- To a file using SeriLog by day under the debug folder in LogFiles folder
- Setup is in Classes\SetupLogging.cs
- Make the connection string invalid to test logging.

