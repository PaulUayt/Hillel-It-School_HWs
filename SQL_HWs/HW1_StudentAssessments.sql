--Створюємо базу
create database StudentsAssessmentsDatabase

-- Переходимо на з'єднання з базою
use StudentsAssessmentsDatabase

--Створюємо таблицю
CREATE TABLE StudentsAssessments
(
	StudentId INT IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Surname NVARCHAR(30) NOT NULL,
	Patronymic NVARCHAR(30) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	Country NVARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	Phone NVARCHAR(20) NOT NULL,
	Email NVARCHAR(30) NULL,
	GroupName NVARCHAR(5) NOT NULL,
	AvregeAssessment FLOAT NOT NULL,
	MinSubjectName NVARCHAR(50) NOT NULL,
	MinSubjectAssessment TINYINT NOT NULL,
	MaxSubjectName NVARCHAR(50) NOT NULL,
	MaxSubjectAssessment TINYINT NOT NULL,
	CONSTRAINT PK_StudentsAssessments_StudentId PRIMARY KEY (StudentId),
	CONSTRAINT UQ_StudentsAssessments_Phone UNIQUE (Phone),
);

-- Додаємо дані до створеної таблиці
INSERT INTO StudentsAssessments
VALUES
('Ivan', 'Shevchenko', 'Petrovych', 'Kyiv', 'Ukraine', '2001-04-12', '+380931112233', 'ivan.shevchenko@example.com', 'KP-01', 87.5, 'Physics', 65, 'Math', 98),
('Olena', 'Kovalenko', 'Ivanivna', 'Lviv', 'Ukraine', '2002-06-22', '+380671234567', 'olena.kov@example.com', 'IT-21', 79.3, 'Chemistry', 60, 'Biology', 92),
('Andrii', 'Bondarenko', 'Mykolaiovych', 'Odesa', 'Ukraine', '2000-11-30', '+380503334455', 'andrii.bond@example.com', 'SE-11', 91.2, 'Geography', 72, 'Informatics', 99),
('Kateryna', 'Melnyk', 'Oleksandrivna', 'Kharkiv', 'Ukraine', '2003-03-17', '+380931234000', 'kat.melnyk@example.com', 'DS-41', 83.7, 'History', 70, 'English', 95),
('Maksym', 'Tkachenko', 'Serhiiovych', 'Dnipro', 'Ukraine', '2001-01-10', '+380631100220', 'maks.tk@example.com', 'KP-01', 65.9, 'Math', 50, 'Music', 80),
('Iryna', 'Sydorenko', 'Vasylivna', 'Ternopil', 'Ukraine', '2002-08-25', '+380993221100', 'iryna.s@example.com', 'IT-21', 79.0, 'Physics', 66, 'Literature', 90),
('Yurii', 'Zhuk', 'Olehovych', 'Vinnytsia', 'Ukraine', '2001-07-03', '+380982211334', 'zhuk.yura@example.com', 'SE-11', 88.8, 'Chemistry', 73, 'History', 96),
('Anastasiia', 'Boiko', 'Andriivna', 'Rivne', 'Ukraine', '2000-12-12', '+380931993344', 'ana.boiko@example.com', 'DS-41', 72.4, 'Art', 55, 'Math', 89),
('Dmytro', 'Hrytsenko', 'Oleksiiovych', 'Poltava', 'Ukraine', '2003-06-06', '+380991234567', 'd.hryts@example.com', 'KP-01', 84.1, 'Physics', 62, 'Informatics', 94),
('Sofiia', 'Levchenko', 'Yuriyivna', 'Zhytomyr', 'Ukraine', '2001-02-28', '+380991112299', 'sofia.lev@example.com', 'IT-21', 90.3, 'Geography', 75, 'Biology', 99);


--■ Відображати всієї інформації з таблиці зі студентами та оцінками.
SELECT * FROM StudentsAssessments

--■ Відображати ПІБ усіх студентів.
SELECT Surname + ' ' + Name + ' ' + Patronymic AS 'Full Name' FROM StudentsAssessments

--■ Відображати усіх середніх оцінок.
SELECT AvregeAssessment FROM StudentsAssessments

--■ Показати ПІБ усіх студентів з мінімальною оцінкою, більшою, ніж зазначена.
SELECT Surname + ' ' + Name + ' ' + Patronymic AS 'Full Name',
	MinSubjectAssessment
FROM StudentsAssessments
WHERE MinSubjectAssessment > 70

--■ Показати країни студентів. Назви країн мають бути унікальними.
SELECT DISTINCT Country FROM StudentsAssessments
-- було отримано тільки одну країну

-- Додамо більше студентів з інших країн для наглядності
INSERT INTO StudentsAssessments
VALUES
('Roma', 'Shevchenko', 'Petrovych', 'Paris', 'France', '2001-04-12', '+380931112234', NULL, 'KP-01', 87.5, 'Physics', 65, 'Math', 98),
('Anna', 'Kovalenko', 'Ivanivna', 'Madrid', 'Spain', '2002-06-22', '+380671235567', NULL, 'IT-21', 79.3, 'Chemistry', 60, 'Biology', 92)

--Тепер знову виконаємо команду
SELECT DISTINCT Country FROM StudentsAssessments
-- тепер було отримано декілька країн


--■ Показати міста студентів. Назви міст мають бути унікальними. + виведемо у від Z-A
SELECT DISTINCT City 
FROM StudentsAssessments
ORDER BY City DESC

--Тепер виведемо ПІБ студентів, які живуть у містах, які починаються на літери 'К' та 'Р'
SELECT Surname + ' ' + Name + ' ' + Patronymic AS 'Full Name', City 
FROM StudentsAssessments
WHERE City LIKE 'K%' OR City LIKE 'P%'


--■ Показати назви груп. Назви груп мають бути унікальними.
SELECT DISTINCT GroupName FROM StudentsAssessments
--Назви предметів мають бути унікальними.

SELECT GroupName FROM StudentsAssessments

--Виведемо ПІБ всіх студентів, які навчаються на 1 курсі в 0-вих групах
SELECT Surname + ' ' + Name + ' ' + Patronymic AS 'Full Name', GroupName
FROM StudentsAssessments
WHERE GroupName LIKE '%%-0%'

--Виведемо студентів, які мають середній бал вище середнього балу по універу
SELECT Surname + ' ' + Name + ' ' + Patronymic AS [Full Name], 
  AvregeAssessment, 
  ( SELECT AVG(AvregeAssessment) FROM StudentsAssessments) as OverallAverageAssessment
FROM StudentsAssessments
WHERE AvregeAssessment > (
  SELECT AVG(AvregeAssessment) 
  FROM StudentsAssessments
);