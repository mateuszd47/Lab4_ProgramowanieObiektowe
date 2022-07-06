USE master;
GO
IF DB_ID (N'SkelpAkwarystyczny  ') IS NOT NULL
DROP DATABASE SkelpAkwarystyczny;

-- Tworzenie bazy danych

CREATE DATABASE SkelpAkwarystyczny
COLLATE Polish_100_CI_AS;
GO
IF DB_ID (N'SkelpAkwarystyczny ') IS NOT NULL
SELECT 'Created database'

-- Tworzenie tabel

USE [SkelpAkwarystyczny]

CREATE TABLE [dbo].[HodowcaPL](
	[id_login] [int] PRIMARY KEY IDENTITY,
	[login] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[adres_email] [varchar](100) NOT NULL,
)


CREATE TABLE[dbo].[Kategoria](
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

CREATE TABLE [dbo].[Klienci](
	[id_klient] [int] PRIMARY KEY IDENTITY,
	[imie] [varchar](100) NOT NULL,
	[nazwisko] [varchar](100) NOT NULL,
	[nr_telefonu] [varchar](20) NOT NULL,
	[adres_email] [varchar](100) NOT NULL,
	[adres] [varchar](100) NOT NULL,
	[kodpocztowy] [varchar](20) NOT NULL,
	[miejscowośc] [varchar](20) NOT NULL,
	[klient_staly] [bit] NOT NULL,
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


CREATE TABLE [dbo].[Zamowienia_Klient](
	[id_zamowienia] [int] NOT NULL FOREIGN KEY REFERENCES Zamowienia(id_zamowienia),
	[data_zlozenia_zamowienia] [datetime] NOT NULL,
	[id_klient] [int] NOT NULL FOREIGN KEY REFERENCES Klienci(id_klien

-- Dane wsadowe do tabel

USE [SkelpAkwarystyczny]

INSERT INTO HodowcaPL (login,password,adres_email)
	VALUES ('Robert','dXDw15gyK9','robert@hodowca.pl'),
	('Zosia','waS13BbPZU','zosia.k@ghodowca.pl'),
	('Tomasz','Riwgy7ikZ7','tomek@hodowca.pl'),

INSERT INTO Kategoria (nazwa_kategori)
	VALUES ('Ryby'),
	('Rośliny'),
	('Filtry'),
	('Grzałki'),
	('Podłoże'),
	('Pokarmy'),
	('Dekoracje'),
	('Akwaria'),
	('Awaria i zestawy')

INSERT INTO Produkt(nazwa_produktu,cena_netto,cena_brutto,id_kategoria,dostepnych_sztuk)
	VALUES ('Młode samce gupiki Pawie Oczk',4.53,5.57,1,100),
	('Devario malabaricus',3.00,3.69,1,240),
	('Kirysek Wenezuela Orange',90,110.71,1,23),
	('Glonojad zbrojnik',28.99,35.67,1,500),
	('Rotala H RA Kubek 10cm',17.99,21.34,2,32),
	('Marsilea hirsuta',17.99,21.34,2,124),
	('Limnobium laevigatum',14.99,15.45,2,15),
	('FLUVAL 107',315.99,387.45,3,3),
	('HYDOR PRIME 10',219.99,269.27,3,16),
	('AQUAEL ULTRA FILTER 900',443.99,340.34,3,9),
	('EHEIM Thermocontrol e25',115.20,145.34,4,28),
	('Grzałka JBL 300W',115.50,150.99,4,0),
	('Oase HeatUp 25',106.36,124.54,4,32),
	('AQUAEL Platinium Heater',84.30,96.12,4,2),
	('Oase ScaperLine Soil 3 l czarny',60.44,82.23,5,100),
	('Oase ScaperLine Soil 3 l brązowy',60.44,82.23,5,100),
	('Oase ScaperLine Soil 9 l czarny',142.99,167.12,5,250),
	('Oase ScaperLine Soil 9 l brązowy',142.99,167.12,5,250),
	('HS aqua Gold',14.00,15.32,6,505),
	('HS aqua Cichlid',59.00,72.57,6,243),
	('Discusfood Spotted Color Booster',105.10,129.27,6,53),
	('ProGrow Crater Stone 1kg',17.99,22.12,7,4),
	('ProGrow Fine Wood Stump Korzeń 1 sztuka 10 KG',680.00,836.40,7,1),
	('PIRATE SKULL EYE-PATCH',20.10,24.72,8,2),
	('Akwarium FULL OPTIWHITE 50x25x25, 4mm, 31L',143.70,176.75,8,29),
	('Akwarium FULL OPTIWHITE 50x35x35cm, 6mm, 60l',345.60,425.08,8,14),
	('Akwarium FloAt Premium 36x38x14cm, 4mm, 19L',166.33,204.59,8,63),
	('AQUAEL FISH&SHRIMP SET DUO DAY&NIGHT BLACK',541.80,666.41,9,0),
	('AQUAEL HEXA SET 60 D&N CZARNY',533.40,656.08,9,6),
	('AQUAEL GLOSSY ST 100 D&N BIAŁY Z SZAFKĄ',2595.40,3192.34,9,11)

INSERT INTO Klienci(imie,nazwisko,nr_telefonu,adres_email,adres,kodpocztowy,miejscowośc,klient_staly)
	VALUES ('Jan','Kowalski','662 231 213','JanKow@wp.pl','Bochnia 31','32-700','Bochnia',0),
	('Mateusz','Dyga','663 121 213','mati@wp.pl','Bochnia 121','32-700','Bochnia',1),
	('Piotr','Nowak','833 231 323','PiNowak@gmail.com','Niepołomice 34','32-005','Niepołomice',0),
	('Marek','Kowalski','663 431 113','Kowal@interia.pl','Kraków 232','31-422','Kraków',0),
	('Antoni','Wiśniewski','523 482 203','antoni.w@gmail.com','Karpatki 232','40-000','Katowice',0),
	('Nina','Walczak','861 942 713','nina15@interia.pl','Portowa 15','80-209','Gdynia',1),
	('Kacper','Wysocki','233 497 643','Kacper.wys@onet.pl','Wolnosci 93','16-402','Szczecin',0)
	

INSERT INTO Zamowienia(id_produktu,sztuk,czy_odebrano)
	VALUES (6,1,0),
(13,12,0),
(21,1,1),
(27,5,0),
(2,115,0),
(3,7,1),
(11,1,1),
(19,2,1),
(30,1,0)


INSERT INTO Zamowienia_Klient(data_zlozenia_zamowienia,id_zamowienia,id_klient)
VALUES ('2022-08-04',4,7),
('2022-08-10',8,3),
('2022-10-25',3,2),
('2022-03-12',2,4),
('2022-11-28',5,1),
('2022-11-29',9,2),
('2022-07-15',1,6),
('2022-10-12',6,6),
('2022-11-25',7,5)
