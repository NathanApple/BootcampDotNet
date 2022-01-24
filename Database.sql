use BootcampDotnetDB

drop table [User];

create table [User]
(UserID int primary key identity(1,1),
    UserName varchar(100),
	BirthDate datetime,
	Ranking int
)

drop table Book;

create table Book
(BookID int primary key identity(1,1),
BookTitle varchar(100),
BookDescription varchar(255), 
Quantity int);


drop table Borrow;

create table Borrow
(BorrowID int primary key identity(1,1),
    UserID INT,
	BookID INT
)

select * from Book;
select * from [User];
select * from Borrow;

insert into Book (BookTitle, BookDescription, Quantity)
values 
('Book1', 'First edition of book',1),
('Book2', 'Second season of book',1),
('Book3', 'Third one',1);

insert into User(UserName, BirthDate, Ranking)
values
('joni', '2004-05-23T14:25:10', 1),
('budi', '2004-05-23T14:25:10', 2),
('alan', '2004-05-23T14:25:10', 3),
