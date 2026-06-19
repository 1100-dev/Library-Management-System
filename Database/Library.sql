-- =========================
-- LIBRARY DATABASE (SAFE)
-- =========================

IF DB_ID('library') IS NULL
    CREATE DATABASE library;
GO

USE library;
GO

-- =========================
-- IRBook TABLE
-- =========================

IF OBJECT_ID('dbo.IRBook', 'U') IS NULL
CREATE TABLE IRBook (
    id INT IDENTITY(1,1) PRIMARY KEY,
    std_enroll VARCHAR(250) NOT NULL,
    std_name VARCHAR(250) NOT NULL,
    std_dep VARCHAR(250) NOT NULL,
    std_sem VARCHAR(250) NOT NULL,
    std_Contact BIGINT NOT NULL,
    std_email VARCHAR(250) NOT NULL,
    book_name VARCHAR(250) NOT NULL,
    book_issue_date VARCHAR(250) NOT NULL,
    book_return_date VARCHAR(250) NULL
);
GO

-- =========================
-- NewBook TABLE
-- =========================

IF OBJECT_ID('dbo.NewBook', 'U') IS NULL
CREATE TABLE NewBook (
    bId INT IDENTITY(1,1) PRIMARY KEY,
    bName VARCHAR(250) NOT NULL,
    bAuthor VARCHAR(250) NOT NULL,
    bPubl VARCHAR(250) NOT NULL,
    bPDate VARCHAR(250) NOT NULL,
    bPrice BIGINT NOT NULL,
    bQuan BIGINT NOT NULL
);
GO

-- =========================
-- NewStudent TABLE
-- =========================

IF OBJECT_ID('dbo.NewStudent', 'U') IS NULL
CREATE TABLE NewStudent (
    stuid INT IDENTITY(1,1) PRIMARY KEY,
    sname VARCHAR(250) NOT NULL,
    enroll VARCHAR(250) NOT NULL,
    dep VARCHAR(250) NOT NULL,
    sem VARCHAR(250) NOT NULL,
    contact BIGINT NOT NULL,
    email VARCHAR(250) NOT NULL
);
GO