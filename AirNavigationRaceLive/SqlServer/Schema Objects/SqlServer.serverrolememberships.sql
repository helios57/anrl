EXECUTE sp_addsrvrolemember @loginame = N'NT AUTHORITY\SYSTEM', @rolename = N'sysadmin';


GO
EXECUTE sp_addsrvrolemember @loginame = N'NT SERVICE\MSSQLSERVER', @rolename = N'sysadmin';


GO
EXECUTE sp_addsrvrolemember @loginame = N'Helios-Laptop\Helios', @rolename = N'sysadmin';


GO
EXECUTE sp_addsrvrolemember @loginame = N'NT SERVICE\SQLSERVERAGENT', @rolename = N'sysadmin';

