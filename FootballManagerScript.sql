USE FootballManagerDB

CREATE TABLE Team (
id int identity(1,1) primary key,
TeamName nvarchar(100),
)

CREATE TABLE Player (
id int identity(1,1) primary key,
[Name] nvarchar(100),
Nationality nvarchar(100),
Position varchar(2),
DateOfBirth datetime,
PreferedFoot varchar(10),
Height int,
[Weight] int,
FK_TeamId int FOREIGN KEY REFERENCES Team(id)
)

INSERT INTO Team VALUES ('Manchester City')