SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[SAIR_ALLTABLESREFERENCINGVEHICLES]
AS
BEGIN
    select cast(f.name as varchar(255)) as foreign_key_name
    , cast(c.name as varchar(255)) as foreign_table
    , cast(fc.name as varchar(255)) as foreign_column
    , cast(p.name as varchar(255)) as parent_table
    , cast(rc.name as varchar(255)) as parent_column
    from  sysobjects f
    inner join sysobjects c on f.parent_obj = c.id
    INNER JOIN sys.tables st ON c.id = st.object_id
    INNER JOIN sys.schemas sc ON st.schema_id = sc.schema_id
    inner join sysreferences r on f.id = r.constid
    inner join sysobjects p on r.rkeyid = p.id
    inner join syscolumns rc on r.rkeyid = rc.id and r.rkey1 = rc.colid
    inner join syscolumns fc on r.fkeyid = fc.id and r.fkey1 = fc.colid
    where f.type = 'F' AND p.name = 'SAIR_VEHICLE' AND fc.name = 'SAIR_VEHIID'
    AND sc.name NOT IN ('vehicleconst')
END

GO
