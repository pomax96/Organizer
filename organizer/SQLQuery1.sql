use BinaryStudio ;

IF DB_ID ('BinaryStudio') IS NULL

create database BinaryStudio
ON
(
NAME = BinaryStudio_DAT,
FILENAME = 'E:\BinaryStudio\BinaryStudio\BinaryStudio_Server\bin\Debug\BinaryStudio.mdf',
SIZE = 10,
MAXSIZE = 50,
FILEGROWTH = 5
)
LOG ON
(
NAME = BinaryStudio_LOG,
FILENAME = 'E:\BinaryStudio\BinaryStudio\BinaryStudio_Server\bin\Debug\BinaryStudio.ldf',
SIZE = 10,
MAXSIZE = 50,
FILEGROWTH = 5
);
IF OBJECT_ID ('dbo.Task','U') IS NOT NULL
DROP TABLE dbo.Task;

IF OBJECT_ID ('dbo.Subtask','U') IS NOT NULL
DROP TABLE dbo.Subtask;




 CREATE TABLE dbo.Subtask
   (
   SubtaskID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
   Text varchar(8000) NOT NULL,
   Completet bit NOT NULL
)

CREATE TABLE dbo.Task
   (
   TaskID int PRIMARY KEY IDENTITY(1,1) NOT NULL,
   SubtaskID int NULL,
   Text varchar(8000) NOT NULL,
   Completet bit NOT NULL,
   Date date NOT NULL ,
   Category varchar(50) NOT NULL,
   
   
   CONSTRAINT Admin_Subtask FOREIGN KEY (SubtaskID)
REFERENCES Subtask (SubtaskID) ON DELETE CASCADE
ON UPDATE CASCADE

  )

 