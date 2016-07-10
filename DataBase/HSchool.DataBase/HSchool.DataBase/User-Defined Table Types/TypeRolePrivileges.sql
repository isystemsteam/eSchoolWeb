CREATE TYPE dbo.TypeRolePrivileges AS TABLE
(
	RolePrivilegeId int,
	RoleId int,
	ModuleId int,
	Privileges nvarchar(50),
	RowNumber int 
)