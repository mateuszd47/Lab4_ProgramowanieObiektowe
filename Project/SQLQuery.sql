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

<<<<<<< HEAD
USE [SkelpyAkwarystyczne]
CREATE TABLE [dbo].[Users](
	[id_user] [int] PRIMARY KEY IDENTITY,
	[login] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
)
=======
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
)

>>>>>>> 7ce3a4f299edc8f351624dbfc83c20b49784e8d3
CREATE TABLE [dbo].[Klienci](
	[id_klient] [int] PRIMARY KEY IDENTITY,
	[imie] [varchar](100) NOT NULL,
	[nazwisko] [varchar](100) NOT NULL,
<<<<<<< HEAD
	[kodPocztowy] [varchar](100) NOT NULL,
	[miesjcowo��] [varchar](100) NOT NULL,
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
=======
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
	[czy_odebrano] [bit] NOT NULL,
)

CREATE TABLE [dbo].[Zamowienia_Klient](
	[id_zamowienia] [int] NOT NULL FOREIGN KEY REFERENCES Zamowienia(id_zamowienia),
	[data_zlozenia_zamowienia] [datetime] NOT NULL,
	[id_klient] [int] NOT NULL FOREIGN KEY REFERENCES Klienci(id_klient)
)


-- Dane wsadowe do tabel

USE [SkelpAkwarystyczny]

INSERT INTO HodowcaPL (login,password,adres_email)
	VALUES ('admin','admin','admin@hodowaca.pl'),
	('Robert','dXDw15gyK9','robert@hodowca.pl'),
	('Zosia','waS13BbPZU','zosia.k@ghodowca.pl'),
	('Tomasz','Riwgy7ikZ7','tomek@hodowca.pl'),
	('Paweł','L88owlBpfP','pawel.rydz@hodowca.pl'),
	('Ela','BsStL1a3Fw','ela.k@hodowca.pl'),
	('Mateusz','Y3GfqrJJAR','mateusz.d@hodowca.pl'),
	('Szymon','AcRXk3SIIf','szymon.n@hoodowca.pl'),
	('Bartosz','905gMZbLua','bartosz@hodowca.pl'),
	('Daniel','7GOAtsDyfH','daniel@hodowca.pl')



INSERT INTO Kategoria (nazwa_kategori)
	VALUES ('Ryby'), --1
	('Rośliny'), --2
	('Filtry'), --3
	('Grzałki'), --4
	('Podłoże'), --5
	('Pokarmy'), --6
	('Dekoracje'), --7
	('Akwaria'), --8
	('Awaria i zestawy'), --9
	('Czyszczenie'), --10
	('Oświetlenie') --11

INSERT INTO Produkt(nazwa_produktu,cena_netto,cena_brutto,id_kategoria,dostepnych_sztuk)
	VALUES ('Młode samce gupiki Pawie Oczk',4.53,5.57,1,100),  --1
	('Devario malabaricus',3.00,3.69,1,240), --2
	('Kirysek Wenezuela Orange',90,110.71,1,23), --3
	('Krewetki czerwon',79.99,85.67,1,400), --4
	('Brzanka purpurowa',5.00,6.43,1,456), --5
	('SUM MICROGLANIS',12.10,14.35,1,79), --6
	('Glonojad zbrojnik',28.99,35.67,1,500), --7
	('Rotala H RA Kubek 10cm',17.99,21.34,2,32), --8
	('Marsilea hirsuta',17.99,21.34,2,124), --9
	('Limnobium laevigatum',14.99,15.45,2,15),  --10
	('FLUVAL 107',315.99,387.45,3,3), --11
	('HYDOR PRIME 10',219.99,269.27,3,16), --12
	('AQUAEL ULTRA FILTER 900',443.99,340.34,3,9), --13
	('Deep Aqua HSB-950B',64.00,79.34,3,31), --14
	('Deep Aqua Pompa AEP-6000 l/h',406.00,486.12,3,80), --15
	('EHEIM Thermocontrol e25',115.20,145.34,4,28), --16
	('Grzałka JBL 300W',115.50,150.99,4,0), --17
	('Oase HeatUp 25',106.36,124.54,4,32), --18
	('AQUAEL Platinium Heater',84.30,96.12,4,2), --19
	('Oase ScaperLine Soil 3 l czarny',60.44,82.23,5,100), --20
	('Oase ScaperLine Soil 3 l brązowy',60.44,82.23,5,100), --21
	('Oase ScaperLine Soil 9 l czarny',142.99,167.12,5,250), --22
	('Oase ScaperLine Soil 9 l brązowy',142.99,167.12,5,250), --23
	('Happet Aragonit 4,0-6,0mm 3kg',15.99,17.80,5,50), --24
	('AQUAFOREST AF Bio Sand 7,5KG',79.99,93.65,5,120), --25
	('HS aqua Gold',14.00,15.32,6,505), --26
	('HS aqua Cichlid',59.00,72.57,6,243), --27
	('Discusfood Spotted Color Booster',105.10,129.27,6,53), --28
	('Seachem Reef Zooplankton 500ml',123.60,145.65,6,24), --29
	('Tropical Spirulina Granulat',248.40,289.34,6,89), --30
	('ProGrow Crater Stone 1kg',17.99,22.12,7,4), --31
	('ProGrow Fine Wood Stump Korzeń 1 sztuka 10 KG',680.00,836.40,7,1), --32
	('PIRATE SKULL EYE-PATCH',20.10,24.72,8,2), --33
	('Akwarium FULL OPTIWHITE 50x25x25, 4mm, 31L',143.70,176.75,8,29), --34
	('Akwarium FULL OPTIWHITE 50x35x35cm, 6mm, 60l',345.60,425.08,8,14), --35
	('Akwarium FloAt Premium 36x38x14cm, 4mm, 19L',166.33,204.59,8,63), --36
	('Akwarium FULL OPTIWHITE 80x40x45, 8mm, 145L',755.60,823.45,8,39), --37
	('Akwarium FULL OPTIWHITE 45X45X45cm, 8mm, 90l',632.90,723.34,8,54), --38
	('AQUAEL FISH&SHRIMP SET DUO DAY&NIGHT BLACK',541.80,666.41,9,0), --39
	('OASE HighLine Optiwhite 200',6099.00,7250.21,9,3), --40
	('Aqualighter Nano Marine Set 15L',481.10,532.31,9,14), --41
	('AQUAEL HEXA SET 60 D&N CZARNY',533.40,656.08,9,6), --42
	('AQUAEL GLOSSY ST 100 D&N BIAŁY Z SZAFKĄ',2595.40,3192.34,9,11), --43
	('Resun Czyścik z gąbką i skrobakiem 2w1 49cm',7.50,9.35,10,150), --44
	('AQUA-NOVA CZYŚCIK MAGNETYCZNY L PŁYWAJĄCY',46.90,53.55,10,50), --45
	('AQUAEL CZYŚCIK MAGNETYCZNY DO AKWARIUM M 6-10mm',43.90,54.34,10,15), --46
	('JBL AQUA-T HANDY CZYŚCIK SKROBAK ZE STALI NIERDZEWNEJ',33.99,41.43,10,63), --47
	('Fluval C.O.B. Nano LED 9000 K',279.00,301.50,11,9), --48
	('Fluval Sea LED Marine 3.0',589.00,645.34,11,35), --49
	('AQUAEL LEDDY SLIM 32W MARINE D&N BIAŁY',297.90,325.34,11,2), --50
	('Skylight AQIR-60H FLUO 60W',1499.00,1567.90,11,0) --51


INSERT INTO Klienci(imie,nazwisko,nr_telefonu,adres_email,adres,kodpocztowy,miejscowośc,klient_staly) -- [1 -> Stały klient / 0 -> Nowy klient] 
	VALUES ('Jan','Kowalski','662 231 213','JanKow@wp.pl','Bochnia 31','32-700','Bochnia',0), --1
	('Mateusz','Dyga','663 121 213','mati@wp.pl','Bochnia 121','32-700','Bochnia',1), --2
	('Piotr','Nowak','833 231 323','PiNowak@gmail.com','Niepołomice 34','32-005','Niepołomice',0), --3
	('Marek','Kowalski','663 431 113','Kowal@interia.pl','Kraków 232','31-422','Kraków',0), --4
	('Antoni','Wiśniewski','523 482 203','antoni.w@gmail.com','Karpatki 232','40-000','Katowice',0), --5
	('Nina','Walczak','861 942 713','nina15@interia.pl','Portowa 15','80-209','Gdynia',1), --6
	('Kacper','Wysocki','233 497 643','Kacper.wys@onet.pl','Wolnosci 93','16-402','Szczecin',0), --7
	('Patryk','Glik','904 894 882','Patryk.g@onet.pl','Maja 1','09-530','Gabin',0), --8
	('Stanisław','Małolepszy','963 700 908','stanislaw.1999@gmail.com','Kamienna 15','38-130','Frysztak',0), --9
	('Adrian','Nowak','495 206 845','adrianek@onet.pl','Bielska 67','26-640','Makowiec',1), --10
	('Patrycja','Jakubowska','324 853 720','patrycja16@wp.pl','Sienna 1','16-050','Michałowo',0), --11
	('Ewa','Malinowska','959 182 808','ewa.mali@onet.pl','Fabryczna 31','42-125','Kamyk',0), --12
	('Leszek','Mazur','670 414 305','Leszek2@gmail.coom','Targowa 13','34-100','Wadowice',0), --13
	('Kamila','Baran','499 156 876','kamila103!@wp.pl','Gajowa 47','37-470','Zakopane',1) --14
	
INSERT INTO Zamowienia(id_produktu,sztuk,czy_odebrano) -- [1 -> Odebrano / 0 -> Nie odebrano] 
	VALUES (6,75,0), --1
	(13,1,0), --2
	(21,1,1), --3
	(27,5,0), --4
	(2,115,1), --5
	(3,7,1), --6
	(11,1,0), --7
	(19,2,1), --8
	(30,1,0), --9
	(50,4,0), --10
	(1,65,1), --11
	(38,10,1), --12
	(42,3,0), --13
	(4,153,0), --14
	(35,2,0), --15
	(9,42,1), --16
	(43,1,0), --17
	(29,5,1) --18

INSERT INTO Zamowienia_Klient(data_zlozenia_zamowienia,id_zamowienia,id_klient)
	VALUES ('2021-08-31',8,3),
	('2021-09-03',3,2),
	('2021-09-15',2,4),
	('2021-10-04',5,1),
	('2021-10-19',9,2),
	('2021-10-26',1,6),
	('2022-01-04',6,6),
	('2022-01-06',7,5),
	('2022-02-25',18,14),
	('2022-04-01',4,10),
	('2022-07-19',16,9),
	('2022-07-22',10,11),
	('2022-08-10',15,13),
	('2022-09-29',11,7),
	('2022-10-12',12,14),
	('2022-10-13',17,8),
	('2022-11-25',8,10),
	('2022-12-08',13,12)

-- Sprawdzenie działania tabeli

SELECT * fROM HodowcaPL
SELECT * fROM Kategoria
SELECT * fROM Klienci
SELECT * fROM Produkt
SELECT * fROM Zamowienia
SELECT * fROM Zamowienia_Klient
>>>>>>> 7ce3a4f299edc8f351624dbfc83c20b49784e8d3
