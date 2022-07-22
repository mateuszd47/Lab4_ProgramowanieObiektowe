USE master;
GO
IF DB_ID (N'SkelpAkwarystyczny  ') IS NOT NULL
DROP DATABASE SkelpyAkwarystyczne;

-- Tworzenie bazy danych

CREATE DATABASE SkelpAkwarystyczny
COLLATE Polish_100_CI_AS;
GO
IF DB_ID (N'SkelpAkwarystyczny ') IS NOT NULL
SELECT 'Created database'

USE [SkelpAkwarystyczny]

CREATE TABLE [dbo].[Users](
	[id_user] [int] PRIMARY KEY IDENTITY,
	[login] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
)

CREATE TABLE [dbo].[HodowcaPL](
	[id_hodowcaPL] [int] PRIMARY KEY IDENTITY,
	[imie] [varchar](100) NOT NULL,
	[nazwisko] [varchar](100) NOT NULL,
	[telefon] [varchar](20) NOT NULL,
	[adres_email] [varchar](100) NOT NULL,
	[adres] [varchar](100) NOT NULL
)

CREATE TABLE [dbo].[Importer](
	[id_importer] [int] PRIMARY KEY IDENTITY,
	[imie] [varchar](100) NOT NULL,
	[nazwisko] [varchar](100) NOT NULL,
	[telefon] [varchar](20) NOT NULL,
	[adres_email] [varchar](100) NOT NULL,
	[adres] [varchar](100) NOT NULL,
	[Kraj] [varchar](30) NOT NULL
)

CREATE TABLE [dbo].[Kategoria](
	[id_kategoria] [int] PRIMARY KEY IDENTITY,
	[nazwa_kategori] [varchar](100) NOT NULL,
)

CREATE TABLE [dbo].[Produkt](
	[id_produktu] [int] PRIMARY KEY IDENTITY,
	[nazwa_produktu] [varchar](100) NOT NULL,
	[cena_netto] [decimal](10, 2) NOT NULL,
	[cena_brutto] [decimal](10, 2) NOT NULL,
	[id_kategoria] [int] NOT NULL FOREIGN KEY REFERENCES Kategoria(id_kategoria),
	[dostepnych_sztuk] [int] NULL,
	[dostepny] [bit] NULL
)

CREATE TABLE [dbo].[HodowcaPL_Importer](
	[id_produktu] [int] NOT NULL FOREIGN KEY REFERENCES Produkt(id_produktu),
	[id_hodowcaPL] [int] NULL FOREIGN KEY REFERENCES HodowcaPL(id_hodowcaPL),
	[id_importer] [int] NULL FOREIGN KEY REFERENCES Importer(id_importer)
) 

CREATE TABLE [dbo].[Klienci](
	[id_klient] [int] PRIMARY KEY IDENTITY,
	[imie] [varchar](100) NOT NULL,
	[nazwisko] [varchar](100) NOT NULL,
	[telefon] [varchar](20) NOT NULL,
	[adres_email] [varchar](100) NOT NULL,
	[adres] [varchar](100) NOT NULL,
	[kodpocztowy] [varchar](20) NOT NULL,
	[klient_staly] [bit] NOT NULL,
)

CREATE TABLE [dbo].[SklepyStacjonarne](
	[id_sklepu] [int] PRIMARY KEY IDENTITY,
	[nazwa_sklepu] [varchar](100) NOT NULL,
	[telefon] [varchar](20) NOT NULL,
	[adres_email] [varchar](100) NOT NULL,
	[adres] [varchar](100) NOT NULL,
	[kodpocztowy] [varchar](20) NOT NULL,
	[miejscowość] [varchar](20) NOT NULL
)

CREATE TABLE [dbo].[Zamowienia](
	[id_zamowienia] [int] PRIMARY KEY IDENTITY,
	[id_produktu] [int] NOT NULL FOREIGN KEY REFERENCES Produkt(id_produktu),
	[sztuk] [int] NOT NULL,
	[czy_odebrano] [bit] NOT NULL
)

CREATE TABLE [dbo].[Zamowienia_Klient](
	[id_zamowienia] [int] NOT NULL FOREIGN KEY REFERENCES Zamowienia(id_zamowienia),
	[data_zlozenia_zamowienia] [datetime] NOT NULL,
	[id_klient] [int] NOT NULL FOREIGN KEY REFERENCES Klienci(id_klient)
)

CREATE TABLE [dbo].[Zamowienia_SklepStacjonarny](
	[id_zamowienia] [int] NOT NULL FOREIGN KEY REFERENCES Zamowienia(id_zamowienia),
	[data_zlozenia_zamowienia] [datetime] NOT NULL,
	[id_SklepStacjonarny] [int] NOT NULL FOREIGN KEY REFERENCES SklepyStacjonarne(id_sklepu)
)


-- 4)wypełniamy bezę danymi

USE [SkelpAkwarystyczny]

INSERT INTO Users (login, password)
VALUES ('admin','admin')

INSERT INTO HodowcaPL (imie,nazwisko,telefon,adres_email,adres)
VALUES ('Rafał','Duda','662 623 678','rafcio23@wp.pl','Kraków 43'),
('Agata','Kowalska','662 633 478','aga43@gamil.com','Kraków 423'),
('Michał','Drożdż','862 223 628','MichDro@interia.pl','Bochnia 121'),
('Rafał','Duda','662 623 678','rafcio23@wp.pl','Kraków 43'),
('Jakub','Sztokmach','762 222 678','Kubus344@gamil.com','Tarnów 24'),
('Monika','Kowalska','663 533 478','MoniaKow43@gamil.com','Kielce 32')

INSERT INTO Importer (imie,nazwisko,telefon,adres_email,adres,Kraj)
VALUES ('Liam','Smith','423 234 422','prututteveyau-2738@yopmail.com','Bristol 34b','Wielka Brytania'),
('Liam','Smith','423 234 422','prututteveyau-2738@yopmail.com','Bristol 34b','Wielka Brytania'),
('Noah','Taylor','212 311 241','letribopigre-8432@yopmail.com','Basildon 12','Wielka Brytania'),
('Jackson','Williams','123 312 123','hammodegreiffe-4842@yopmail.com','Burnley 23a','Wielka Brytania'),
('Aiden','Jones','242 745 123','leuseuwouhabroi-8356@yopmail.com','Chatham 23','Wielka Brytania'),
('Elijah','Davis','342 745 123','weverivuto-1138@yopmail.com','Hamburg 234','Niemcy'),
('Noah','Thomas','242 745 123','razejasoje-6299@yopmail.com','Berlin 312','Niemcy'),
('Ben','Miller','241 745 524','groprequoigrole-9273@yopmail.com','Abertamy 213','Czechy'),
('Matteo','Wilson','245 745 323','frebruwayobri-5232@yopmail.com','Bor 211','Czechy'),
('Finn','Roy','442 745 523','ratravureitru-6310@yopmail.com','Brno 421','Czechy'),
('Leon','Wilson','242 745 323','pregrurafficru-2281@yopmail.com','Brno 221','Czechy')

INSERT INTO Kategoria (nazwa_kategori)
VALUES ('Ryby'),
('Rośliny'),
('Filtry'),
('Grzałki'),
('Podłoże'),
('Oświetlenie'),
('Dekoracje'),
('Akwaria'),
('Awaria i zestawy')

INSERT INTO Klienci(imie,nazwisko,telefon,adres_email,adres,kodpocztowy,klient_staly)
VALUES ('Jan','Kowalski','662 231 213','JanKow@wp.pl','Bochnia 31','32-700',0),
('Mateusz','Dyga','663 121 213','mati@wp.pl','Bochnia 121','32-700',1),
('Piotr','Nowak','833 231 323','PiNowak@gmail.com','Niepołomice 34','32-005',0),
('Marek','Kowalski','663 431 113','Kowal@interia.pl','Kraków 232','31-422',0)

INSERT INTO Produkt(nazwa_produktu,cena_netto,cena_brutto,id_kategoria,dostepnych_sztuk,dostepny)
VALUES ('Neon Czerwony',3.47,4.50,1,1000,1),
('Neon Innesa',3.08,4.00,1,500,1),
('Zwinnik czerwonousty',3.85,5.00,1,200,1),
('Mieczyk Hellera',3.85,5.00,1,5000,1),
('Molinezja żaglopłetwa',4.24,5.50,1,0,1),
('JBL e1902',592.23,899,3,22,1),
('Mikrozorium oskrzydlone',15.40,20.00,2,50,1),
('Anubias Bartera',23.10,30.00,2,0,0),
('Grzałka AQUAEL 150W',77,100,4,5,1),
('AQUAEL ULTRAMAX 2000',23.10,30.00,3,0,0),
('Grzałka JBL 300W',115.50,150.00,4,0,0),
('Korzeń mangrowiec',16.94,22.00,7,90,1),
('Korzeń red moor',48.51,63.00,7,20,1),
('Łupek Drzewiasty Kamień do Akwarium',3.85,5.00,7,20,1),
('AQUAEL OPTI SET 200l AKWARIUM Z SZAFKĄ',1309.00,1700.00,9,10,1),
('AQUAEL AKWARIUM PROFILOWANE 45L',92.40,120.00,8,15,1)

INSERT INTO HodowcaPL_Importer (id_produktu,id_importer)
VALUES (3,2),
(1,3),
(2,8)

INSERT INTO HodowcaPL_Importer (id_produktu,id_hodowcaPL)
VALUES (4,2),
(5,6)

INSERT INTO SklepyStacjonarne(nazwa_sklepu,telefon,adres_email,adres,kodpocztowy, miejscowość)
VALUES ('Fajna Rybka','621 731 282','FajnaRybka@gmail.com','Kraków 53','31-831','Kraków'),
('Jasiołek Barbara - Sklep zoologiczny','721 731 282','JasiBarbara@gmail.com','Bochnia 23','32-700','Bochnia'),
('Fiord Sklep zoologiczny','621 231 282','FiordSklepBoch@gmail.com','Bochnia 13','32-700','Bochnia'),
('Kakadu','821 831 882','Kakadu@gmail.com','Kraków 5','31-831','Kraków')

INSERT INTO Zamowienia(id_produktu,sztuk,czy_odebrano)
VALUES (1,100,0),
(2,100,0),
(2,200,0),
(2,100,0),
(3,50,0),
(4,200,0),
(16,4,1),
(16,2,0),
(15,10,1),
(16,4,0),
(7,10,0),
(7,20,0),
(8,10,0),
(14,1,0),
(15,1,1),
(13,1,0)

INSERT INTO Zamowienia_Klient(data_zlozenia_zamowienia,id_zamowienia,id_klient)
VALUES ('2022-04-12',11,2),
('2022-01-22',12,3),
('2021-03-12',13,4),
('2022-03-12',14,4),
('2022-01-03',15,4),
('2022-01-29',16,2)

INSERT INTO Zamowienia_SklepStacjonarny(data_zlozenia_zamowienia,id_zamowienia,id_SklepStacjonarny)
VALUES ('2022-03-12',1,1),
('2022-03-12',3,1),
('2022-03-12',7,1),
('2022-04-12',2,2),
('2022-04-30',4,2),
('2022-04-30',5,2),
('2022-04-30',6,1),
('2021-01-01',8,1),
('2021-12-31',9,1),
('2022-12-31',10,2)



-- użyj jeśli chcesz sprawdzić tabele

SELECT * FROM Users
SELECT * fROM HodowcaPL
SELECT * fROM HodowcaPL_Importer
SELECT * fROM Importer
SELECT * fROM Kategoria
SELECT * fROM Klienci
SELECT * fROM Produkt
SELECT * fROM SklepyStacjonarne
SELECT * fROM Zamowienia
SELECT * fROM Zamowienia_Klient
SELECT * fROM Zamowienia_SklepStacjonarny

UPDATE Klienci SET imie = 'imie', nazwisko = 'nazwisko', telefon = '666666666', adres_email = 'mati@wp.pl', kodpocztowy = '32-700', adres = 'Bochnia21', klient_staly= '1' WHERE id_klient = '1' 
