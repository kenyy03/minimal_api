CREATE DATABASE DbPrueba;

USE DbPrueba

CREATE TABLE Ability(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
	Description NVARCHAR(150)
)

INSERT INTO Ability(Description)
VALUES('Pensamiento Critico')

select * from Ability

