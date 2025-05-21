--Створіть базу даних Лікарня (Hospital), яка міститиме інформацію про обстеження, які проводяться в лікарні.
CREATE DATABASE Hospital

USE Hospital

--Обстеження, які проводяться в лікарні, представлені у вигляді таблиці Обстеження (Examinations), в якій зібрано основну інформацію: назва обстеження, день тижня, коли проводиться обстеження, а також час початку та завершення.
--Також у базі даних є інформація про персонал лікарні, яка зберігається в таблиці Лікарі (Doctors).
--Дані про відділення та захворювання містяться в таблицях Відділення (Departments) та Захворювання (Diseases) відповідно.
--Опис палат зберігається в таблиці Палати (Wards).

--Відділення (Departments) 

--¦ Ідентифікатор (Id). Унікальний ідентифікатор відділення.
--? Тип даних — int.
--? Автоприріст.
--? Не містить null-значення.
--? Первинний ключ.

--¦ Корпус (Building). Номер корпусу, в якому знаходиться відділення.
--? Тип даних — int.
--? Не містить null-значення.
--? Має бути в діапазоні від 1 до 5.

--¦ Фінансування (Financing). Фонд фінансування відділення.
--? Тип даних для зберігання грошових значень.
--? Не містить null-значення.
--? Не може бути менше, ніж 0.
--? Значення за замовчуванням — 0.

--¦ Назва (Name). Назва відділення.
--? Тип даних — nvarchar(100).
--? Не містить null-значення.
--? Не може бути порожньою.
--? Має бути унікальною.

CREATE TABLE Departments
(
	DepartmentId INT IDENTITY,
	Building TINYINT NOT NULL,
	Financing MONEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Departments_DepartmentId PRIMARY KEY (DepartmentId),
	CONSTRAINT CK_Departments_Building CHECK (Building>=1 and Building <=5),
	CONSTRAINT CK_Departments_Name CHECK (Name <> '')
)

INSERT INTO Departments (Building, Financing, Name) VALUES
(1, 100000, 'Cardiology'),
(2, 150000, 'Neurology'),
(3, 200000, 'Surgery'),
(4, 175000, 'Pediatrics'),
(5, 120000, 'Oncology'),
(1, 98000, 'Orthopedics'),
(2, 110000, 'Radiology'),
(3, 135000, 'Dermatology'),
(4, 90000, 'Psychiatry'),
(5, 125000, 'Urology');


--Захворювання (Diseases) 

--¦ Ідентифікатор (Id). Унікальний ідентифікатор захворювання.
--? Тип даних — int.
--? Автоприріст.
--? Не містить null-значення.
--? Первинний ключ.

--¦ Назва (Name). Назва захворювання.
--? Тип даних — nvarchar(100).
--? Не містить null-значення.
--? Не може бути порожньою.
--? Має бути унікальною.

--¦ Ступінь тяжкості (Severity). Ступінь тяжкості захворювання.
--? Тип даних — int.
--? Не містить null-значення.
--? Не може бути менше, ніж 1.
--? Значення за замовчуванням — 1.

CREATE TABLE Diseases
(
	DiseaseId INT IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Severity TINYINT NOT NULL DEFAULT 1,
	CONSTRAINT PK_Diseases_DiseaseId PRIMARY KEY (DiseaseId),
	CONSTRAINT CK_Diseases_Name CHECK (Name <> ''),
	CONSTRAINT CK_Diseases_Severity CHECK (Severity > 0 AND Severity < 16)
)

INSERT INTO Diseases VALUES
('Flu', 2),
('Covid-19', 10),
('Asthma', 5),
('Cancer', 14),
('Diabetes', 7),
('Migraine', 3),
('Tuberculosis', 9),
('Pneumonia', 8),
('Arthritis', 4),
('Eczema', 6);


--Лікарі (Doctors) 

--¦ Ідентифікатор (Id). Унікальний ідентифікатор лікаря.
--? Тип даних — int.
--? Автоприріст.
--? Не містить null-значення.
--? Первинний ключ.

--¦ Ім’я (Name). Ім’я лікаря.
--? Тип даних — nvarchar(max).
--? Не містить null-значення.
--? Не може бути порожнє.

--¦ Телефон (Phone). Телефонний номер лікаря.
--? Тип даних — char(10).
--? Може містити null-значення.

--¦ Ставка (Salary). Ставка лікаря.
--? Тип даних для зберігання грошових значень.
--? Не містить null-значення.
--? Не може бути меншою або дорівнювати 0.

--¦ Прізвище (Surname). Прізвище лікаря.
--? Тип даних — nvarchar(max).
--? Не містить null-значення.
--? Не може бути порожнє.

CREATE TABLE Doctors
(
	DoctorId INT IDENTITY,
	Name NVARCHAR(50) NOT NULL,
	Surname NVARCHAR(max) NOT NULL,
	Phone CHAR(10) NULL,
	Salary MONEY NOT NULL,
	Allowance MONEY NOT NULL,
	CONSTRAINT PK_Doctors_DoctorId PRIMARY KEY (DoctorId),
	CONSTRAINT CK_Doctors_Name CHECK (Name <> ''),
	CONSTRAINT CK_Doctors_Surname CHECK (Surname <> ''),
	CONSTRAINT CK_Doctors_Salary CHECK (Salary>0),
	CONSTRAINT CK_Doctors_Allowance CHECK (Allowance>0),
)

INSERT INTO Doctors (Name, Surname, Phone, Salary, Allowance) VALUES
('John', 'Smith', '1234567890', 50000, 10000),
('Alice', 'Johnson', '2345678901', 52000, 8000),
('Robert', 'Brown', '3456789012', 54000, 6000),
('Emily', 'Davis', '4567890123', 51000, 7500),
('Michael', 'Miller', '5678901234', 56000, 2000),
('Olivia', 'Wilson', '6789012345', 53000, 3000),
('William', 'Moore', '7890123456', 55000, 9000),
('Emma', 'Taylor', '8901234567', 58000, 5000),
('James', 'Anderson', '9012345678', 59000, 7000),
('Sophia', 'Thomas', '0123456789', 60000, 11000);


--Обстеження (Examinations) 

--¦ Ідентифікатор (Id). Унікальний ідентифікатор обстеження.
--? Тип даних — int.
--? Автоприріст.
--? Не містить null-значення.
--? Первинний ключ.

--¦ День тижня (DayOfWeek). День тижня, коли проводиться обстеження.
--? Тип даних — int.
--? Не містить null-значення.
--? Має бути в діапазоні від 1 до 7.

--¦ Час завершення (EndTime). Час завершення обстеження.
--? Тип даних для зберігання часу.
--? Не містить null-значення.
--? Має бути більше, ніж час початку обстеження.

--¦ Назва (Name). Назва обстеження.
--? Тип даних — nvarchar(100).
--? Не містить null-значення.
--? Не може бути порожньою.
--? Має бути унікальною.

--¦ Час початку (StartTime). Час початку обстеження.
--? Тип даних для зберігання часу.
--? Не містить null-значення.
--? Має бути в діапазоні від 8:00 до 18:00.


CREATE TABLE Examinations
(
	ExaminationId INT IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	DayOfWeek INT NOT NULL,
	StartTime TIME NOT NULL,
	EndTime TIME NOT NULL,
	CONSTRAINT PK_Examinations_ExaminationId PRIMARY KEY (ExaminationId),
	CONSTRAINT CK_Examinations_Name CHECK (Name <> ''),
	CONSTRAINT CK_Examinations_DayOfWeek CHECK (DayOfWeek>0 AND DayOfWeek<8),
	CONSTRAINT CK_Examinations_StartTime CHECK (StartTime>'08:00:00' AND StartTime<'18:00:00'),
	CONSTRAINT CK_Examinations_EndTime CHECK (EndTime>StartTime),
)

INSERT INTO Examinations (Name, DayOfWeek, StartTime, EndTime) VALUES
('General Checkup', 1, '09:00:00', '09:30:00'),
('Blood Test', 2, '10:00:00', '10:20:00'),
('MRI', 3, '11:00:00', '12:00:00'),
('X-Ray', 4, '13:00:00', '13:30:00'),
('Cardiology Consult', 5, '14:00:00', '15:00:00'),
('Surgery Pre-Op', 6, '15:30:00', '16:30:00'),
('Post-Op Check', 7, '10:00:00', '10:30:00'),
('Allergy Test', 1, '11:00:00', '11:15:00'),
('Eye Exam', 2, '12:00:00', '12:30:00'),
('Dermatology', 3, '09:30:00', '10:00:00');


--Палати (Wards) 

--¦ Ідентифікатор (Id). Унікальний ідентифікатор.
--? Тип даних — int.
--? Автоприріст.
--? Не містить null-значення
--? Первинний ключ.

--¦ Корпус (Building). Номер корпусу, де знаходиться палата.
--? Тип даних — int.
--? Не містить null-значення.
--? Має бути в діапазоні від 1 до 5.

--¦ Поверх (Floor). Номер поверху, на якому знаходиться палата.
--? Тип даних — int.
--? Не містить null-значення.
--? Не може бути менше, ніж 1.

--¦ Назва (Name). Назва палати.
--? Тип даних — nvarchar(20).
--? Не містить null-значення.
--? Не може бути порожньою.
--? Має бути унікальною.

CREATE TABLE Wards
(
	WardId INT IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Floor INT NOT NULL,
	Building INT NOT NULL,
	CONSTRAINT PK_Wards_WardId PRIMARY KEY (WardId),
	CONSTRAINT CK_Wards_Name CHECK (Name <> ''),
	CONSTRAINT UQ_Wards_Name UNIQUE(Name),
	CONSTRAINT CK_Wards_Building CHECK (Building>0 AND Building<6),
)

INSERT INTO Wards (Name, Floor, Building) VALUES
('Ward A1', 1, 1),
('Ward B1', 2, 2),
('Ward C1', 3, 3),
('Ward D1', 4, 4),
('Ward E1', 5, 5),
('Ward F1', 2, 1),
('Ward G1', 3, 2),
('Ward H1', 4, 3),
('Ward I1', 1, 4),
('Ward J1', 2, 5);


--Для бази даних «Лікарня» створіть такі запити:

--1. Вивести вміст таблиці палат.
SELECT * FROM Wards

--2. Вивести прізвища та телефони усіх лікарів.
SELECT Surname, Phone FROM Doctors

--3. Вивести усі поверхи без повторень, де розміщуються палати.
SELECT DISTINCT Floor FROM Wards

--4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease».
SELECT Name AS [Name of Disease], 
	Severity AS [Severity of Disease]
FROM Diseases

--5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми.
-- запит 5.1 - вивести кількість лікарів та середню зарплату лікарів без надбавки
SELECT COUNT(DoctorId) AS [Count of Doctors],
	AVG(Salary) AS [Average Salary of Doctors]
FROM Doctors

-- запит 5.2 - вивести кількість поверхів у будівлі
SELECT Building, COUNT(*) AS [Count of Floors] FROM Wards
GROUP BY Building

-- запит 5.3 - вивести тривалість кожного прийому
SELECT Name, StartTime, EndTime, 
	DATEDIFF(MINUTE, StartTime, EndTime) AS [Time of Examination] 
FROM Examinations


--6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 100000.
SELECT Name FROM Departments
WHERE Building=1 AND Financing<=100000

--7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 120000 до 150000.
SELECT Name FROM Departments
WHERE Building=3 AND (Financing BETWEEN 120000 AND 150000)

--8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі.
SELECT Name FROM Wards
WHERE (Building=4 OR Building=5) AND Floor=1

--9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 1 або 3 та мають фонд фінансування менший, ніж 11000 або більший за 25000.
SELECT Name, Building, Financing FROM Departments
WHERE (Building=3 OR Building=1) AND (Financing<110000 OR Financing>150000)

--10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 1500.
SELECT Name FROM Doctors 
WHERE (Salary+Allowance)>60000

--11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавку.
SELECT Surname FROM Doctors
WHERE (Salary/2)>(Allowance*3)

--12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00.
SELECT DISTINCT Name FROM Examinations
WHERE (DayOfWeek BETWEEN 1 AND 3) AND (StartTime BETWEEN '10:00:00' AND '15:00:00')


--13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 8 або 10.
SELECT Name, Building FROM Departments
WHERE Building IN (1,3,8,10)

--14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го.
SELECT Name FROM Diseases
WHERE NOT (Severity=2 OR Severity=3)

--15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі.
SELECT Name FROM Departments
WHERE NOT (Building=1 OR Building=3)

--16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі.
SELECT Name FROM Departments
WHERE Building=1 OR Building=3

--17. Вивести прізвища лікарів, що починаються з літери «M».
SELECT Surname FROM Doctors
WHERE Surname LIKE 'M%'
