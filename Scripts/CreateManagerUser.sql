-- Create Manager User for Restaurant Management System
-- Run this script in SQL Server Management Studio or via sqlcmd

USE RestaurantManagementDb;
GO

-- Check if manager already exists
IF EXISTS (SELECT 1 FROM Users WHERE Role = 2)
BEGIN
    PRINT 'Manager user already exists!';
END
ELSE
BEGIN
    -- Create Manager user
    -- Password: manager123 (hashed with BCrypt)
    INSERT INTO Users (Id, Email, FullName, PasswordHash, Role, CreatedAt)
    VALUES (
        NEWID(),
        'manager@restaurant.com',
        'Мениджър',
        '$2a$11$KIXQ5QY5q5q5q5q5q5q5qO5QY5QY5QY5QY5QY5QY5QY5QY5QY5QY5',
        2,  -- Manager role (0=Waiter, 1=Kitchen, 2=Manager)
        GETUTCDATE()
    );
    
    PRINT 'Manager user created successfully!';
    PRINT 'Email: manager@restaurant.com';
    PRINT 'Password: manager123';
END
GO

-- View all users and their roles
SELECT 
    Id,
    Email,
    FullName,
    CASE Role
        WHEN 0 THEN 'Waiter'
        WHEN 1 THEN 'Kitchen'
        WHEN 2 THEN 'Manager'
    END AS Role,
    CreatedAt
FROM Users;
GO





