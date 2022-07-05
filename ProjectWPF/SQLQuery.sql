USE master;
GO
IF DB_ID (N'SkelpyAkwarystyczne ') IS NOT NULL
DROP DATABASE SkelpyAkwarystyczne;

CREATE DATABASE SkelpyAkwarystyczne
COLLATE Polish_100_CI_AS;
GO
IF DB_ID (N'SkelpyAkwarystyczne ') IS NOT NULL
SELECT 'Created database'

CREATE TABLE [dbo].[HodowcaPL](
	[id_login] [int] PRIMARY KEY IDENTITY,
	[login] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
)