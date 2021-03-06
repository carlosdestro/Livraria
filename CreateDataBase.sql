USE MASTER
GO

CREATE DATABASE Livraria
GO

USE LIVRARIA
GO

CREATE TABLE Idioma (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(255) NOT NULL)
	GO

CREATE TABLE Editora (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(255) NOT NULL)
	GO

CREATE TABLE Genero (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(255) NOT NULL)
	GO

CREATE TABLE Livro (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	NOME VARCHAR(255) NOT NULL,
	AUTOR VARCHAR(255) NOT NULL,
	IDIOMA_ID INT NOT NULL FOREIGN KEY REFERENCES IDIOMA(ID),
	EDITORA_ID int FOREIGN KEY REFERENCES EDITORA(ID),
	EDICAO INT NOT NULL,
	GENERO_ID int FOREIGN KEY REFERENCES GENERO(ID),
	DATA_PUBLICACAO DATE NOT NULL,
	DATA_CADASTRO DATETIME2 NOT NULL DEFAULT GETDATE(),
	QUANTIDADE INT NOT NULL,
	DATA_ALTERACAO DATETIME2 NOT NULL DEFAULT GETDATE())
	GO

INSERT INTO IDIOMA(NOME)
VALUES
	('Portugu�s'),
	('Ingl�s')
	GO

INSERT INTO EDITORA(NOME)
VALUES
	('Penguin'),
	('DarkSide'),
	('Intr�nseca'),
	('John Wiley & Sons')
	GO

INSERT INTO GENERO(NOME)
VALUES
	('Cl�ssicos de Fic��o'),
	('Horror Literatura e Fic��o'),
	('F�sica')
	GO	
	
INSERT INTO LIVRO (NOME, AUTOR, IDIOMA_ID, EDITORA_ID, EDICAO, GENERO_ID, DATA_CADASTRO, QUANTIDADE, DATA_PUBLICACAO)
VALUES
	('Il�ada', 'Homero', 1, 1 , 1, 1, GETDATE(), 10, '2013-02-06'),
	('Odisseia', 'Homero', 1, 1, 1, 1, GETDATE(), 3, '2011-10-10'),
	('Dr�cula', 'Bram Stoker', 1, 2, 1, 2, GETDATE(), 5, '2018-10-24'),
	('O Universo Numa Casca de Noz', 'Stephen Hawking', 1, 3, 1, 3, GETDATE(), 1, '2016-02-06'),
	('Uma Breve Hist�ria do Tempo', 'Stephen Hawking', 1, 3, 1, 3, GETDATE(), 4, '2015-01-22'),
	('Microsoft SQL Server 2012 Bible', 'Adam Jorgensen', 2, 4, 1, 3, GETDATE(), 9, '2012-08-28')
	GO

