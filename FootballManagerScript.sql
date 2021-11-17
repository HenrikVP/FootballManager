USE MASTER
IF DB_ID('FootballManagerDB') IS NOT NULL
BEGIN
    ALTER DATABASE FootballManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE FootballManagerDB
END
CREATE DATABASE FootballManagerDB
USE FootballManagerDB 
GO

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
FK_TeamId int
--CONSTRAINT FKTeamId FOREIGN KEY (FK_TeamId) REFERENCES Team(id)
)

--ALTER TABLE Player DROP CONSTRAINT FKTeamId
--TRUNCATE TABLE Team
--INSERT INTO Team VALUES ('Manchester City'), ('Newcastle'), ('Tottenham Spurs')

--SELECT * FROM Team