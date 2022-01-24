# Book Library
By Nathaniel Candra 2540120521
Last updated at 21/01/2022

## Instalation
- Use previous database from Bootcamp1
- Open SQL
- Create database BootcampDotnetDB ( if not exist )
- Run database.sql
- The app should be work now, try running it
- If it doesn't, try changing connection string in startup.cs

## Table Created
Assume that you already have table from training session, here is few table that i created

### Book
- BookID 
- BookTitle
- BookDescription
- Quantity

### Borrow
- BorrowID
- UserID
- BookID

### User 
( this table should already exist in your database, but just in case )

- UserID
- UserName
- BirthData
- Ranking

## New Feature Path
Although you could see the navigation in navbar, to make it simpler i will state that new feature could be access in
- (website)/BorrowDB
- (website)/BookDB
