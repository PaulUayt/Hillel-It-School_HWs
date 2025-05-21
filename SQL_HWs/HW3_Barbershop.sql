CREATE DATABASE Barbershop
GO

USE Barbershop
GO

CREATE TABLE BarberLevels 
(
	BarberLevelId TINYINT IDENTITY,
	Level NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_BarberLevels_BarberLevelId PRIMARY KEY (BarberLevelId)
);
GO

CREATE TABLE Genders 
(
	GenderId TINYINT IDENTITY,
	TypeGender NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_Genders_GenderId PRIMARY KEY (GenderId)
);
GO

CREATE TABLE Barbers 
(
	BarberId INT IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	GenderId TINYINT NOT NULL,
	Phone VARCHAR(13) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Birthday DATE NOT NULL,
	StartWorkDate DATE NOT NULL,
	BarberLevelId TINYINT NOT NULL,

	CONSTRAINT PK_Barbers_BarberId PRIMARY KEY  (BarberId),
	CONSTRAINT UQ_Barbers_Phone UNIQUE (Phone),
	CONSTRAINT UQ_Barbers_Email UNIQUE (Email),
	CONSTRAINT CK_Barbers_Birthday CHECK (DATEDIFF(year, Birthday, GETDATE()) >= 18),
	CONSTRAINT FK_Barbers_To_Genders FOREIGN KEY (GenderId) REFERENCES Genders (GenderId),
	CONSTRAINT FK_Barbers_To_BarberLevels FOREIGN KEY (BarberLevelId) REFERENCES BarberLevels (BarberLevelId) 
);
GO

CREATE TABLE Customers
(
	CustomerId INT IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Surname NVARCHAR(50) NOT NULL,
	Patronymic NVARCHAR(50) NOT NULL,
	Phone VARCHAR(13) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	GenderId TINYINT NOT NULL,

	CONSTRAINT PK_Customers_CustomerId PRIMARY KEY  (CustomerId),
	CONSTRAINT UQ_Customers_Phone UNIQUE (Phone),
	CONSTRAINT UQ_Customers_Email UNIQUE (Email),
	CONSTRAINT FK_Customers_To_Genders FOREIGN KEY (GenderId) REFERENCES Genders (GenderId),
);
GO

CREATE TABLE BarberServices
(
	BarberServiceId INT IDENTITY,
	Name NVARCHAR(100) NOT NULL,
	Duration TIME NOT NULL,
	Price MONEY NOT NULL,
	BarberLevelId TINYINT NOT NULL,

	CONSTRAINT PK_BarberServices_BarberServiceId PRIMARY KEY  (BarberServiceId),
	CONSTRAINT FK_BarberServices_To_BarberLevels FOREIGN KEY (BarberLevelId) REFERENCES BarberLevels (BarberLevelId)
);
GO


CREATE TABLE Ratings 
(
	RatingId INT IDENTITY,
	TypeRatings NVARCHAR(30) NOT NULL,
	CONSTRAINT PK_Ratings_RatingId PRIMARY KEY (RatingId)
);
GO


CREATE TABLE Requests
(
	RequestId INT IDENTITY,
	CustomerVisitedServiceId INT NOT NULL,
	RatingId INT NOT NULL,
	Feedback NVARCHAR(MAX) NULL,
	Date DATE NOT NULL,

	CONSTRAINT PK_Requests_RequestId PRIMARY KEY  (RequestId),
	CONSTRAINT FK_Requests_To_Ratings FOREIGN KEY (RatingId) REFERENCES Ratings (RatingId)
);
GO

CREATE TABLE CustomerVisitedServices
(
	CustomerVisitedServiceId INT IDENTITY,
	CustomerId INT NOT NULL,
	BarberId INT NOT NULL,
	BarberServiceId INT NOT NULL,
	Date DATE NOT NULL,
	StartTime TIME NOT NULL,
	EndTime TIME NOT NULL,

	CONSTRAINT PK_CustomerVisitedServices_CustomerVisitedServiceId PRIMARY KEY  (CustomerVisitedServiceId),
	CONSTRAINT CK_CustomerVisitedServices_StartTime CHECK (StartTime>'09:00:00' AND StartTime<'20:00:00'),
	CONSTRAINT CK_CustomerVisitedServices_EndTime CHECK (EndTime>StartTime),
	CONSTRAINT FK_CustomerVisitedServices_To_CustomerVisitedServices FOREIGN KEY (CustomerId) REFERENCES Customers (CustomerId),
	CONSTRAINT FK_CustomerVisitedServices_To_Barbers FOREIGN KEY (BarberId) REFERENCES Barbers (BarberId),
	CONSTRAINT FK_CustomerVisitedServices_To_BarberServices FOREIGN KEY (BarberServiceId) REFERENCES BarberServices (BarberServiceId)
);
GO


CREATE TABLE AppointmentsToBarbers
(
	AppointmentId INT IDENTITY,
	CustomerId INT NOT NULL,
	BarberId INT NOT NULL,
	BarberServiceId INT NOT NULL,
	Date DATE NOT NULL,
	StartTime TIME NOT NULL,
	EndTime TIME NOT NULL,

	CONSTRAINT PK_AppointmentsToBarbers_AppointmentId PRIMARY KEY  (AppointmentId),
	CONSTRAINT CK_AppointmentsToBarbers_StartTime CHECK (StartTime>'09:00:00' AND StartTime<'20:00:00'),
	CONSTRAINT CK_AppointmentsToBarbers_EndTime CHECK (EndTime>StartTime),
	CONSTRAINT FK_AppointmentsToBarbers_To_CustomerVisitedServices FOREIGN KEY (CustomerId) REFERENCES Customers (CustomerId),
	CONSTRAINT FK_AppointmentsToBarbers_To_Barbers FOREIGN KEY (BarberId) REFERENCES Barbers (BarberId),
	CONSTRAINT FK_AppointmentsToBarbers_To_BarberServices FOREIGN KEY (BarberServiceId) REFERENCES BarberServices (BarberServiceId),
);
GO

INSERT INTO Genders (TypeGender) VALUES
(N'Чоловіча'),
(N'Жіноча'),
(N'Бінарна'),
(N'Невизначено');
GO

INSERT INTO Ratings (TypeRatings) VALUES
(N'Дуже погано'),
(N'Погано'),
(N'Нормально'),
(N'Добре'),
(N'Чудово');
GO

INSERT INTO BarberLevels (Level) VALUES
(N'Чиф-барбер'),      -- ID = 1
(N'Синьйор-барбер'),  -- ID = 2
(N'Джуніор-барбер');  -- ID = 3
GO

INSERT INTO Barbers (Name, Surname, Patronymic, GenderId, Phone, Email, Birthday, StartWorkDate, BarberLevelId)
VALUES 
(N'Олег', N'Ковальчук', N'Іванович', 1, '380671111111', 'oleg@barber.com', '1990-05-12', '2015-03-01', 1),
(N'Андрій', N'Сидоренко', N'Миколайович', 1, '380672222222', 'andriy@barber.com', '1992-07-22', '2016-06-15', 2),
(N'Ірина', N'Петренко', N'Олександрівна', 2, '380673333333', 'iryna@barber.com', '1995-01-30', '2020-02-10', 3),
(N'Марія', N'Бондар', N'Андріївна', 2, '380674444444', 'maria@barber.com', '1988-12-12', '2013-04-25', 2),
(N'Артем', N'Шевченко', N'Юрійович', 1, '380675555555', 'artem@barber.com', '1996-03-17', '2021-08-01', 3),
(N'Олексій', N'Данилюк', N'Олегович', 1, '380676666666', 'oleksiy@barber.com', '1994-09-10', '2019-11-01', 3),
(N'Катерина', N'Литвин', N'Ігорівна', 2, '380677777777', 'katya@barber.com', '1990-04-04', '2018-05-20', 2),
(N'Сергій', N'Мельник', N'Валерійович', 1, '380678888888', 'serhiy@barber.com', '1993-06-01', '2017-01-15', 2);
GO


INSERT INTO Customers (Name, Surname, Patronymic, Phone, Email, GenderId)
VALUES 
(N'Віталій', N'Дубенко', N'Олегович', '380931111111', 'vitaliy@mail.com', 1),
(N'Оксана', N'Романенко', N'Іванівна', '380932222222', 'oksana@mail.com', 2),
(N'Ігор', N'Ткаченко', N'Павлович', '380933333333', 'ihor@mail.com', 1),
(N'Аліна', N'Козак', N'Артемівна', '380934444444', 'alina@mail.com', 2),
(N'Максим', N'Шульга', N'Олександрович', '380935555555', 'maksym@mail.com', 1),
(N'Юлія', N'Герасименко', N'Євгенівна', '380936666666', 'yuliya@mail.com', 2),
(N'Олена', N'Пономаренко', N'Богданівна', '380937777777', 'olena@mail.com', 2),
(N'Богдан', N'Кравченко', N'Сергійович', '380938888888', 'bogdan@mail.com', 1),
(N'Тарас', N'Семенов', N'Ігорович', '380939999999', 'taras@mail.com', 3),
(N'Лідія', N'Яковенко', N'Григорівна', '380931010101', 'lidiya@mail.com', 2),
(N'Віра', N'Савченко', N'Андріївна', '380932020202', 'vira@mail.com', 4),
(N'Руслан', N'Демченко', N'Назарович', '380933030303', 'ruslan@mail.com', 1);
GO

INSERT INTO BarberServices (Name, Duration, Price, BarberLevelId)
VALUES 
(N'Чоловіча стрижка', '00:30:00', 300, 2),
(N'Жіноча стрижка', '00:45:00', 400, 2),
(N'Стрижка бороди', '00:20:00', 150, 3),
(N'Гоління небезпечною бритвою', '00:30:00', 350, 2),
(N'Дитяча стрижка', '00:25:00', 200, 3),
(N'Модельна стрижка', '00:40:00', 500, 1),
(N'Фарбування волосся', '01:00:00', 600, 2),
(N'Укладка волосся', '00:15:00', 100, 3),
(N'Камуфлювання сивини', '00:25:00', 250, 3),
(N'Комплекс: стрижка+борода', '01:00:00', 550, 2),
(N'SPA для волосся', '00:50:00', 700, 2),
(N'Фейд', '00:35:00', 450, 1);
GO


INSERT INTO CustomerVisitedServices (CustomerId, BarberId, BarberServiceId, Date, StartTime, EndTime)
VALUES 
(1, 1, 6, '2025-04-10', '10:00:00', '10:40:00'),  -- Модельна стрижка
(1, 1, 12, '2025-04-10', '10:40:00', '11:15:00'), -- Фейд
(2, 2, 1, '2025-04-11', '11:00:00', '11:30:00'),  -- Чоловіча стрижка
(2, 2, 10, '2025-04-11', '11:30:00', '12:30:00'), -- Комплекс: стрижка+борода
(3, 3, 3, '2025-04-12', '09:30:00', '09:50:00'), -- Стрижка бороди
(3, 3, 8, '2025-04-12', '09:50:00', '10:05:00'), -- Укладка волосся
(4, 4, 7, '2025-04-13', '13:00:00', '14:00:00'), -- Фарбування волосся
(4, 4, 11, '2025-04-13', '14:00:00', '14:50:00'), -- SPA для волосся
(5, 5, 9, '2025-04-14', '15:00:00', '15:25:00'), -- Камуфлювання сивини
(6, 6, 5, '2025-04-15', '12:00:00', '12:25:00'), -- Дитяча стрижка
(7, 7, 2, '2025-04-16', '16:00:00', '16:45:00'), -- Жіноча стрижка
(8, 8, 4, '2025-04-17', '17:00:00', '17:30:00'); -- Гоління небезпечною бритвою
GO


INSERT INTO AppointmentsToBarbers (CustomerId, BarberId, BarberServiceId, Date, StartTime, EndTime)
VALUES
(1, 2, 1, '2025-04-01', '10:00:00', '10:30:00'),
(2, 4, 2, '2025-04-02', '11:00:00', '11:45:00'),
(3, 5, 3, '2025-04-03', '14:00:00', '14:20:00'),
(4, 1, 6, '2025-04-04', '12:00:00', '12:40:00'),
(5, 6, 5, '2025-04-05', '15:00:00', '15:25:00'),
(6, 2, 4, '2025-04-06', '09:30:00', '10:00:00'),
(7, 7, 7, '2025-04-07', '10:15:00', '11:15:00'),
(8, 3, 1, '2025-04-08', '13:00:00', '13:30:00'),
(9, 4, 10, '2025-04-09', '12:30:00', '13:30:00'),
(10, 2, 11, '2025-04-10', '11:00:00', '11:50:00'),
(1, 1, 12, '2025-04-11', '16:00:00', '16:35:00'),
(2, 6, 8, '2025-04-12', '17:00:00', '17:15:00');
GO

INSERT INTO Requests (CustomerVisitedServiceId, RatingId, Feedback, Date)
VALUES
(1, 5, N'Все сподобалося, приємний барбер.', '2025-04-01'),
(2, 4, N'Нормально, але трохи довго чекати.', '2025-04-02'),
(3, 3, N'Послуга відповідає очікуванням.', '2025-04-03'),
(4, 5, N'Супер! Рекомендую!', '2025-04-04'),
(5, 2, N'Не дуже сподобалось, прохолодно в залі.', '2025-04-05'),
(6, 4, NULL, '2025-04-06'),
(7, 5, N'Професійно і приємно.', '2025-04-07'),
(8, 4, N'Все на рівні.', '2025-04-08'),
(9, 3, NULL, '2025-04-09'),
(10, 5, N'Майстер супер! Робота – топ!', '2025-04-10'),
(11, 1, N'Невдоволений результатом.', '2025-04-11'),
(12, 4, N'Усе добре, дякую.', '2025-04-12');
GO

SELECT C.Name, B.Name, BS.Name, Date, StartTime, EndTime
FROM CustomerVisitedServices AS CVS
JOIN Customers AS C ON C.CustomerId = CVS.CustomerId
JOIN Barbers AS B ON B.BarberId = CVS.BarberId
JOIN BarberServices AS BS ON BS.BarberServiceId = CVS.BarberServiceId
GO

--Використовуючи тригери, функції користувача, збережені процедури реалізуйте наступну функціональність: 

--■ Повернути ПІБ всіх барберів салону. 
CREATE PROCEDURE FullNameAllBarbers AS
BEGIN
	SELECT Surname + ' ' + Name + ' ' + Patronymic AS [Full Name] FROM Barbers
END

EXEC FullNameAllBarbers;
GO
--■ Повернути інформацію про всіх синьйор-барберів. 
CREATE PROCEDURE AllSeniorBarbers AS
BEGIN 
	SELECT * FROM Barbers
	WHERE BarberLevelId=2
END

EXEC AllSeniorBarbers
GO
--■ Повернути інформацію про всіх барберів, які можуть надати послугу традиційного гоління бороди. 
CREATE PROCEDURE AllBeardShavingBarbers AS
BEGIN 
	SELECT * FROM Barbers AS B
	JOIN BarberServices AS BS ON BS.BarberLevelId = B.BarberLevelId
	WHERE BS.Name=N'Стрижка бороди'
END

EXEC AllBeardShavingBarbers
GO

--■ Повернути інформацію про всіх барберів, які можуть надати конкретну послугу. 
--Інформація про потрібну послугу надається як параметр.
CREATE PROCEDURE CurrentServiceBarbers
	@service NVARCHAR(50)
AS
SELECT * FROM Barbers AS B
JOIN BarberServices AS BS ON BS.BarberLevelId = B.BarberLevelId
WHERE BS.Name=@service

EXEC CurrentServiceBarbers N'Фарбування волосся'
GO

EXEC CurrentServiceBarbers N'Укладка волосся'
GO

EXEC CurrentServiceBarbers N'Фейд'
GO


--■ Повернути інформацію про всіх барберів, які працюють понад зазначену кількість років. 
--Кількість років передається як параметр. 
CREATE PROCEDURE GetBarbersByExpirience
	@exp INT
AS
SELECT * FROM Barbers
WHERE DATEDIFF(year, StartWorkDate, GETDATE()) > @exp

EXEC GetBarbersByExpirience 5
GO

EXEC GetBarbersByExpirience 7
GO

EXEC GetBarbersByExpirience 10
GO

--■ Повернути кількість синьйор-барберів та кількість джуніор-барберів. 
CREATE PROCEDURE GetCountBarbers AS
SELECT BL.Level, COUNT(*) AS [Count] FROM Barbers AS B
JOIN BarberLevels AS BL ON BL.BarberLevelId=B.BarberLevelId
WHERE BL.Level = N'Синьйор-барбер' OR BL.Level = N'Джуніор-барбер'
GROUP BY BL.Level

EXEC GetCountBarbers
GO


--■ Повернути інформацію про постійних клієнтів. Критерій постійного клієнта: був у салоні задану кількість разів. 
--Кількість передається як параметр.
CREATE PROCEDURE GetRegularCustomers 
  @MinVisits INT
AS
SELECT 
	C.CustomerId,
	C.Surname + ' ' + C.Name + ' ' + C.Patronymic AS [Full Name],
	C.Phone,
	COUNT(CVS.CustomerVisitedServiceId) AS VisitCount
FROM Customers AS C
JOIN CustomerVisitedServices AS CVS ON C.CustomerId = CVS.CustomerId
GROUP BY C.CustomerId, C.Surname, C.Name, C.Patronymic, C.Phone
HAVING COUNT(CVS.CustomerVisitedServiceId) >= @MinVisits;
	
EXEC GetRegularCustomers 1
GO

EXEC GetRegularCustomers 2
GO

EXEC GetRegularCustomers 3
GO

INSERT INTO CustomerVisitedServices (CustomerId, BarberId, BarberServiceId, Date, StartTime, EndTime)
VALUES 
(1, 1, 6, '2025-02-10', '10:00:00', '10:40:00')  -- Модельна стрижка

--■ Заборонити можливість видалення інформації про чиф-барбер, якщо не додано другий чиф-барбер. 
CREATE TRIGGER Barbers_CheafBarber_DELETE
ON Barbers
INSTEAD OF DELETE
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM deleted 
        WHERE BarberLevelId = 1
    )
    BEGIN
        DECLARE @RemainingChiefs INT

        SELECT @RemainingChiefs = COUNT(*) 
        FROM Barbers 
        WHERE BarberLevelId = 1 
        AND BarberId NOT IN (SELECT BarberId FROM deleted)

        IF @RemainingChiefs = 0
        BEGIN
            RAISERROR('Неможливо видалити останнього чиф-барбера. Додайте іншого чифа перед видаленням.', 16, 1)
            RETURN
        END
    END

    DELETE FROM Barbers
    WHERE BarberId IN (SELECT BarberId FROM deleted)
END;

DELETE Barbers
WHERE BarberLevelId=1

--■ Заборонити додавати барберів молодше 21 року
CREATE TRIGGER Barbers_INSERT
ON Barbers
INSTEAD OF INSERT
AS
BEGIN 
	IF EXISTS (
		SELECT 1 FROM inserted
		WHERE DATEDIFF(year, Birthday, GETDATE()) < 21
	)
	BEGIN
		RAISERROR('Неможливо додати барбера молодше 21 року.', 16, 1)
        RETURN
	END
END

INSERT INTO Barbers (Name, Surname, Patronymic, GenderId, Phone, Email, Birthday, StartWorkDate, BarberLevelId)
VALUES 
(N'Олег', N'Діванов', N'Іванович', 1, '380671111112', 'oleg1@barber.com', '2006-05-12', '2015-03-01', 2)

INSERT INTO Barbers (Name, Surname, Patronymic, GenderId, Phone, Email, Birthday, StartWorkDate, BarberLevelId)
VALUES 
(N'Олег', N'Діванов', N'Іванович', 1, '380671111112', 'oleg1@barber.com', '2002-05-12', '2015-03-01', 2)
GO
--Функції користувача

--■ Функція користувача повертає вітання в стилі «Hello, ІМ'Я!» Де ІМ'Я передається як параметр. 
--Наприклад, якщо передали Nick, то буде Hello, Nick! 
CREATE FUNCTION GetGreeting (@Name NVARCHAR(100))
RETURNS NVARCHAR(200)
AS
BEGIN
    RETURN 'Hello, ' + @Name + '!'
END;
GO

SELECT dbo.GetGreeting('Nick') AS Greeting;
GO
SELECT dbo.GetGreeting('Паша') AS Greeting;
GO
SELECT dbo.GetGreeting('Діма') AS Greeting;
GO
-- Результат: Hello, Nick!


--■ Функція користувача повертає інформацію про поточну кількість хвилин; 
CREATE FUNCTION dbo.GetCurrentMinute ()
RETURNS INT AS
BEGIN 
	RETURN DATEPART(MINUTE, GETDATE())
END
GO

SELECT dbo.GetCurrentMinute() AS [Current Minute];
GO
--■ Функція користувача повертає інформацію про поточний рік; 
CREATE FUNCTION dbo.GetCurrentYear ()
RETURNS INT AS
BEGIN 
	RETURN YEAR(GETDATE())
END
GO

SELECT dbo.GetCurrentYear() AS [Current Year];
GO

--■ Функція користувача повертає інформацію про те: парний або непарний рік; 
CREATE FUNCTION dbo.GetEvenOrOddYear (
	@year INT
)
RETURNS NVARCHAR(20) AS
BEGIN
	IF ((@year%2) = 0)
		RETURN 'Парний рік'
	RETURN 'Непарний рік'
END
GO

SELECT 2020 AS Year, dbo.GetEvenOrOddYear(2020) AS [Evenness];
GO
SELECT 2019 AS Year, dbo.GetEvenOrOddYear(2019) AS [Evenness];
GO

--■ Функція користувача приймає число і повертає yes, якщо число просте і no, якщо число не просте; 
CREATE FUNCTION dbo.CheckingOnSimpleNumber (
	@num INT
)
RETURNS CHAR(3) AS
BEGIN
	IF (@num<=1)
		RETURN 'NO'

	DECLARE @i INT
	SET @i=FLOOR(SQRT(@num))

	WHILE @i >= 2
		BEGIN
			IF ((@num%@i) = 0)
				RETURN 'NO'

			SET @i=@i-1
		END

	RETURN 'YES'
END

SELECT dbo.CheckingOnSimpleNumber(23), dbo.CheckingOnSimpleNumber(22), dbo.CheckingOnSimpleNumber(12)
GO

--■ Функція користувача приймає як параметри п'ять чисел. 
--Повертає суму мінімального та максимального значення з переданих п'яти параметрів;
CREATE FUNCTION dbo.SumMinAndMaxNumbers (
	@num1 INT, 
	@num2 INT, 
	@num3 INT, 
	@num4 INT, 
	@num5 INT
)
RETURNS INT AS
BEGIN
	DECLARE @ArrayNums TABLE (Num INT NOT NULL)
	INSERT INTO @ArrayNums 
	VALUES 
		(@num1),
		(@num2),
		(@num3),
		(@num4),
		(@num5);
	DECLARE @sum INT;
	SET @sum = (SELECT MAX(Num) FROM @ArrayNums) + (SELECT MIN(Num) FROM @ArrayNums)

	RETURN @sum
END
GO

SELECT dbo.SumMinAndMaxNumbers(1,-5,2,3,5) AS [Sum MIN and MAX nums]
GO

--■ Функція користувача показує всі парні або непарні числа в переданому діапазоні. 
--Функція приймає три параметри: початок діапазону, кінець діапазону, парне чи непарне показувати.
CREATE FUNCTION dbo.GetEvenOrOddRangeNumbers (
	@startNum INT, 
	@endNum INT, 
	@typeNum BIT 
)
RETURNS @Result TABLE (Num INT NOT NULL) 
AS
BEGIN
	WHILE @endNum >= @startNum
		BEGIN
			IF (@typeNum=0 AND (@startNum%2) = 0)
				INSERT INTO @Result VALUES (@startNum);
			ELSE IF (@typeNum=1 AND (@startNum%2) = 1)
				INSERT INTO @Result VALUES (@startNum);
			SET @startNum = @startNum + 1
		END
	RETURN
END
GO

SELECT * FROM dbo.GetEvenOrOddRangeNumbers(1,10,0)
GO
SELECT * FROM dbo.GetEvenOrOddRangeNumbers(1,10,1)
GO

--Збережені процедури

--Створіть наступні збережені процедури: 

--■ Збережена процедура виводить «Hello, world!»; 
CREATE PROCEDURE PrintHelloWorld
AS
PRINT 'Hello, world!'

EXEC PrintHelloWorld
GO

--■ Збережена процедура повертає інформацію про поточний час;
CREATE PROCEDURE GetCurrentTime
AS
PRINT CONVERT(TIME, GETDATE());
GO

EXEC GetCurrentTime
GO

--■ Збережена процедура повертає інформацію про поточну дату;
CREATE PROCEDURE GetCurrentDate
AS
PRINT GETDATE();
GO

EXEC GetCurrentDate
GO

--■ Збережена процедура приймає три числа і повертає їхню суму;
CREATE PROCEDURE GetSumNum (
	@num1 INT,
	@num2 INT,
	@num3 INT
)
AS
PRINT @num1 + @num2 + @num3
GO

EXEC GetSumNum 5,-5,33
GO

--■ Збережена процедура приймає три числа і повертає середньоарифметичне трьох чисел;
CREATE PROCEDURE GetAvgNum (
	@num1 FLOAT,
	@num2 FLOAT,
	@num3 FLOAT
)
AS
PRINT (@num1 + @num2 + @num3)/3.0
GO

EXEC GetAvgNum 5,-5,33
GO

--■ Збережена процедура приймає три числа і повертає максимальне значення;
CREATE PROCEDURE GetMaxNum (
	@num1 FLOAT,
	@num2 FLOAT,
	@num3 FLOAT
)
AS
BEGIN
	IF (@num1 > @num2 AND @num1 > @num3)
		PRINT @num1
	ELSE IF (@num2 > @num1 AND @num2 > @num3)
		PRINT @num2
	ELSE 
		PRINT @num3
END
GO

EXEC GetMaxNum 5,-5,33
GO
EXEC GetMaxNum 5,-5,-33
GO

--■ Збережена процедура приймає три числа і повертає мінімальне значення;
CREATE PROCEDURE GetMinNum (
	@num1 FLOAT,
	@num2 FLOAT,
	@num3 FLOAT
)
AS
BEGIN
	IF (@num1 < @num2 AND @num1 < @num3)
		PRINT @num1
	ELSE IF (@num2 < @num1 AND @num2 < @num3)
		PRINT @num2
	ELSE 
		PRINT @num3
END
GO

EXEC GetMinNum 5,-5,33
GO
EXEC GetMinNum 5,-5,-33
GO

--■ Збережена процедура приймає число та символ. 

--В результаті роботи збереженої процедури відображається  лінія довжиною, що дорівнює числу. Лінія побудована із символу, вказаного у другому параметрі. 

--Наприклад, якщо було передано 5 та #, ми отримаємо лінію такого виду #####; 
CREATE PROCEDURE LineFromChar (
	@num INT,
	@sym CHAR(1)
)
AS
BEGIN
	DECLARE @line NVARCHAR(MAX);
	SET @line = '';
	WHILE @num > 0
	BEGIN
		SET @line = @line + @sym
		SET @num = @num - 1 
	END
	PRINT @line
END
GO

EXEC LineFromChar 25, '%'
GO
EXEC LineFromChar 5, '#'
GO

--■ Збережена процедура приймає як параметр число і повертає його факторіал. 
--Формула розрахунку факторіалу: n! = 1 * 2 * ... n. Наприклад, 3! = 1 * 2 * 3 = 6; 
CREATE PROCEDURE GetFactorial (
	@num INT
)
AS
BEGIN
	DECLARE @result INT;
	SET @result=1
	WHILE @num > 0
	BEGIN
		SET @result=@result*@num
		SET @num = @num - 1 
	END
	PRINT @result
END
GO

EXEC GetFactorial 5
GO
EXEC GetFactorial 3
GO

--■ Збережена процедура приймає два числові параметри. Перший параметр – це число. 

--Другий параметр – це ступінь. Процедура повертає число, зведене до ступеня. 
--Наприклад, якщо параметри дорівнюють 2 і 3, тоді повернеться 2 у третьому ступені, тобто 8.
CREATE PROCEDURE GetPowerNum (
	@base INT,
	@exponent INT
)
AS
BEGIN
	PRINT POWER(@base, @exponent)
END
GO

EXEC GetPowerNum 5, 2
GO
EXEC GetPowerNum 5, 3
GO
