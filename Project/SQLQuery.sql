USE master;
GO
IF DB_ID (N'SkelpyAkwarystyczne ') IS NOT NULL
DROP DATABASE SkelpyAkwarystyczne;

CREATE DATABASE SkelpyAkwarystyczne
COLLATE Polish_100_CI_AS;
GO
IF DB_ID (N'SkelpyAkwarystyczne ') IS NOT NULL
SELECT 'Created database'

USE [SkelpyAkwarystyczne]
CREATE TABLE [dbo].[Users](
	[id_user] [int] PRIMARY KEY IDENTITY,
	[login] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
)
CREATE TABLE [dbo].[Klienci](
	[id_klient] [int] PRIMARY KEY IDENTITY,
	[imie] [varchar](100) NOT NULL,
	[nazwisko] [varchar](100) NOT NULL,
	[kodPocztowy] [varchar](100) NOT NULL,
	[miesjcowoœæ] [varchar](100) NOT NULL,
	[telefon] [varchar](11) NOT NULL,
)
CREATE TABLE [dbo].[Kategoria](
	[id_kategoria] [int] PRIMARY KEY IDENTITY,
	[nazwa_kategori] [varchar](100) NOT NULL,
)
CREATE TABLE [dbo].[Produkt](
	[id_produkt] [int] PRIMARY KEY IDENTITY,
	[nazwa_produkt] [varchar](100) NOT NULL,
	[cena_netto] [decimal](10, 2) NOT NULL,
	[cena_brutto] [decimal](10, 2) NOT NULL,
	[id_kategoria] [int] NOT NULL FOREIGN KEY REFERENCES Kategoria(id_kategoria),
	[dostepny] [bit] NULL
)
CREATE TABLE [dbo].[Zamowienia](
	[id_zamowienia] [int] PRIMARY KEY IDENTITY,
	[id_produktu] [int] NOT NULL FOREIGN KEY REFERENCES Produkt(id_produkt),
	[sztuk] [int] NOT NULL,
)


INSERT INTO Users (login, password)
VALUES ('admin','admin')

SELECT * FROM Users