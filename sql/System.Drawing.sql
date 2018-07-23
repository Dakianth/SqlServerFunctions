USE [ProlexNet]
GO

ALTER DATABASE [ProlexNet] SET TRUSTWORTHY ON;
GO

CREATE ASSEMBLY [System.Drawing] 
AUTHORIZATION [dbo]
FROM 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Drawing.dll'
WITH PERMISSION_SET = UNSAFE;
GO

--ALTER DATABASE [ProlexNet] SET TRUSTWORTHY OFF;
--GO

EXEC sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
EXEC sp_configure 'clr enabled'
GO