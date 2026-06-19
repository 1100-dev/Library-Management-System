-- =========================
-- LOGIN DATABASE (SAFE)
-- =========================

IF DB_ID('Login') IS NULL
    CREATE DATABASE Login;
GO

USE Login;
GO

-- =========================
-- TABLE
-- =========================

IF OBJECT_ID('dbo.loginTable', 'U') IS NULL
CREATE TABLE loginTable (
    id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(150) NOT NULL,
    pass VARCHAR(150) NOT NULL
);
GO

-- =========================
-- SEED DATA (SAFE INSERT)
-- =========================

IF NOT EXISTS (SELECT * FROM loginTable WHERE username = 'Rabia')
INSERT INTO loginTable (username, pass) VALUES ('Rabia', 'pass');

IF NOT EXISTS (SELECT * FROM loginTable WHERE username = 'Sonia')
INSERT INTO loginTable (username, pass) VALUES ('Sonia', '123');
GO